using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace hamarb123.SharpGLES.UWP
{
	/*
	 * Copyright (c) 2015-2016 Xamarin, Inc.
	 * Copyright (c) 2017-2018 Microsoft Corporation.
	 * 
	 * Permission is hereby granted, free of charge, to any person obtaining a copy of
	 * this software and associated documentation files (the "Software"), to deal in
	 * the Software without restriction, including without limitation the rights to
	 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
	 * the Software, and to permit persons to whom the Software is furnished to do so,
	 * subject to the following conditions:
	 * 
	 * The above copyright notice and this permission notice shall be included in all
	 * copies or substantial portions of the Software.
	 * 
	 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
	 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
	 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
	 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
	 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
	 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	 * 
	 * Modified by Hamish Arblaster.
	 */
	public class GLESSwapChainPanel : SwapChainPanel
	{
		private static readonly DependencyProperty ProxyVisibilityProperty =
			DependencyProperty.Register(
				"ProxyVisibility",
				typeof(Visibility),
				typeof(GLESSwapChainPanel),
				new PropertyMetadata(Visibility.Visible, OnVisibilityChanged));

		private static readonly bool designMode = DesignMode.DesignModeEnabled;

		private readonly object locker = new object();

		private bool isVisible = true;
		private bool isLoaded = false;

		private GLESContext glesContext;

		private IAsyncAction renderLoopWorker;
		private IAsyncAction renderOnceWorker;

		private bool enableRenderLoop;

		public GLESSwapChainPanel()
		{
			glesContext = null;

			renderLoopWorker = null;
			renderOnceWorker = null;

			DrawInBackground = false;
			EnableRenderLoop = false;

			ContentsScale = CompositionScaleX;

			Loaded += OnLoaded;
			Unloaded += OnUnloaded;

			CompositionScaleChanged += OnCompositionChanged;
			SizeChanged += OnSizeChanged;

			var binding = new Binding
			{
				Path = new PropertyPath(nameof(Visibility)),
				Source = this
			};
			SetBinding(ProxyVisibilityProperty, binding);
		}

		public bool DrawInBackground { get; set; }

		public double ContentsScale { get; private set; }

		public bool EnableRenderLoop
		{
			get => enableRenderLoop;
			set
			{
				if (enableRenderLoop != value)
				{
					enableRenderLoop = value;
					UpdateRenderLoop(value);
				}
			}
		}

		public void Invalidate()
		{
			if (!isLoaded || EnableRenderLoop)
				return;

			if (DrawInBackground)
			{
				lock (locker)
				{
					// if we haven't fired a render thread, start one
					if (renderOnceWorker == null)
					{
						renderOnceWorker = ThreadPool.RunAsync(RenderOnce);
					}
				}
			}
			else
			{
				// draw on this thread, blocking
				RenderFrame();
			}
		}

		public event EventHandler OnRender;

		private Action OnCreate = null;
		private Action OnDestroy = null;

		private bool DoneOnCreate = false;

		public void SetHandleFunctions(Action OnCreate, Action OnDestroy)
		{
			if (this.OnCreate != null) throw new Exception("Functions already set");
			if (OnCreate == null || OnDestroy == null) throw new ArgumentNullException("Argument cannot be null", new Exception());
			this.OnCreate = OnCreate;
			this.OnDestroy = OnDestroy;
			if (DoneOnCreate)
			{
				OnCreate();
			}
		}

		protected virtual void OnRenderFrame()
		{
			if (!DoneOnCreate)
			{
				DoneOnCreate = true;
				OnCreate?.Invoke();
			}
			OnRender?.Invoke(this, new EventArgs());
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			glesContext = new GLESContext();

			isLoaded = true;

			ContentsScale = CompositionScaleX;

			EnsureRenderSurface();
			UpdateRenderLoop(EnableRenderLoop);
			Invalidate();
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			CompositionScaleChanged -= OnCompositionChanged;
			SizeChanged -= OnSizeChanged;

			UpdateRenderLoop(false);
			DestroyRenderSurface();

			isLoaded = false;

			glesContext?.Dispose();
			glesContext = null;
		}

		private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is GLESSwapChainPanel panel && e.NewValue is Visibility visibility)
			{
				panel.isVisible = visibility == Visibility.Visible;
				panel.UpdateRenderLoop(panel.isVisible);
				panel.Invalidate();
			}
		}

		private void OnCompositionChanged(SwapChainPanel sender, object args)
		{
			ContentsScale = CompositionScaleX;

			DestroyRenderSurface();
			EnsureRenderSurface();
			Invalidate();
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			EnsureRenderSurface();
			Invalidate();
		}

		private void EnsureRenderSurface()
		{
			if (isLoaded && glesContext?.HasSurface != true && ActualWidth > 0 && ActualHeight > 0)
			{
				// detach and re-attach the size events as we need to go after the event added by ANGLE
				// otherwise our size will still be the old size

				SizeChanged -= OnSizeChanged;
				CompositionScaleChanged -= OnCompositionChanged;

				glesContext.CreateSurface(this, null, CompositionScaleX);

				SizeChanged += OnSizeChanged;
				CompositionScaleChanged += OnCompositionChanged;
			}
		}

		private void DestroyRenderSurface()
		{
			if (DoneOnCreate)
			{
				OnDestroy?.Invoke();
			}
			OnCreate = null;
			OnDestroy = null;
			DoneOnCreate = false;

			glesContext?.DestroySurface();
		}

		private void RenderFrame()
		{
			if (designMode || !isLoaded || !isVisible || glesContext?.HasSurface != true)
				return;

			glesContext.MakeCurrent();
			glesContext.GetSurfaceDimensions(out panelWidth, out panelHeight);
			glesContext.SetViewportSize(panelWidth, panelHeight);

			OnRenderFrame();

			if (!glesContext.SwapBuffers())
			{
				// The call to eglSwapBuffers might not be successful (i.e. due to Device Lost)
				// If the call fails, then we must reinitialize EGL and the GL resources.
			}
		}

		public int panelWidth;
		public int panelHeight;

		private void UpdateRenderLoop(bool start)
		{
			if (!isLoaded)
				return;

			lock (locker)
			{
				if (start)
				{
					// if the render loop is not running, start it
					if (renderLoopWorker?.Status != AsyncStatus.Started)
					{
						renderLoopWorker = ThreadPool.RunAsync(RenderLoop);
					}
				}
				else
				{
					// stop the current render loop
					renderLoopWorker?.Cancel();
					renderLoopWorker = null;
				}
			}
		}

		private void RenderOnce(IAsyncAction action)
		{
			if (DrawInBackground)
			{
				// run on this background thread
				RenderFrame();
			}
			else
			{
				// run in the main thread, block this one
				Dispatcher.RunAsync(CoreDispatcherPriority.Normal, RenderFrame).AsTask().Wait();
			}

			lock (locker)
			{
				// we are finished, so null out
				renderOnceWorker = null;
			}
		}

		private void RenderLoop(IAsyncAction action)
		{
			while (action.Status == AsyncStatus.Started)
			{
				if (DrawInBackground)
				{
					// run on this background thread
					RenderFrame();
				}
				else
				{
					// run in the main thread, block this one
					Dispatcher.RunAsync(CoreDispatcherPriority.Normal, RenderFrame).AsTask().Wait();
				}
			}
		}
	}
}
