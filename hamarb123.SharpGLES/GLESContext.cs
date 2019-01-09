using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using EGLDisplay_ = System.IntPtr;
using EGLContext = System.IntPtr;
using EGLConfig = System.IntPtr;
using EGLSurface = System.IntPtr;

namespace hamarb123.SharpGLES.UWP
{
	internal class GLESContext : IDisposable
	{
		private bool isDisposed = false;

		private EGLDisplay_ eglDisplay;
		private EGLContext eglContext;
		private EGLSurface eglSurface;
		private EGLConfig eglConfig;

		public GLESContext()
		{
			eglConfig = SkiaEGL.EGL_NO_CONFIG;
			eglDisplay = EGL.EGL_NO_DISPLAY;
			eglContext = EGL.EGL_NO_CONTEXT;
			eglSurface = EGL.EGL_NO_SURFACE;

			Initialize();
		}

		public bool HasSurface => eglSurface != EGL.EGL_NO_SURFACE;

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
					// dispose managed resources
				}

				// free unmanaged resources
				DestroySurface();
				Cleanup();

				isDisposed = true;
			}
		}

		~GLESContext()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void CreateSurface(SwapChainPanel panel, Size? renderSurfaceSize, float? resolutionScale)
		{
			if (panel == null)
			{
				throw new ArgumentNullException("SwapChainPanel parameter is invalid");
			}

			EGLSurface surface = EGL.EGL_NO_SURFACE;

			int[] surfaceAttributes = new[]
			{
				// EGL_ANGLE_SURFACE_RENDER_TO_BACK_BUFFER is part of the same optimization as EGL_ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER (see above).
				// If you have compilation issues with it then please update your Visual Studio templates.
				EGLX.EGL_ANGLE_SURFACE_RENDER_TO_BACK_BUFFER, EGL.EGL_TRUE,
				EGL.EGL_NONE
			};

			// Create a PropertySet and initialize with the EGLNativeWindowType.
			PropertySet surfaceCreationProperties = new PropertySet();
			surfaceCreationProperties.Add(SkiaEGL.EGLNativeWindowTypeProperty, panel);

			// If a render surface size is specified, add it to the surface creation properties
			if (renderSurfaceSize.HasValue)
			{
				PropertySetExtensions.AddSize(surfaceCreationProperties, SkiaEGL.EGLRenderSurfaceSizeProperty, renderSurfaceSize.Value);
			}

			// If a resolution scale is specified, add it to the surface creation properties
			if (resolutionScale.HasValue)
			{
				PropertySetExtensions.AddSingle(surfaceCreationProperties, SkiaEGL.EGLRenderResolutionScaleProperty, resolutionScale.Value);
			}

			surface = EGL.CreateWindowSurface(eglDisplay, eglConfig, surfaceCreationProperties, surfaceAttributes);
			if (surface == EGL.EGL_NO_SURFACE)
			{
				throw new Exception("Failed to create EGL surface");
			}

			eglSurface = surface;
		}

		public void GetSurfaceDimensions(out int width, out int height)
		{
			EGL.QuerySurface(eglDisplay, eglSurface, EGL.EGL_WIDTH, out width);
			EGL.QuerySurface(eglDisplay, eglSurface, EGL.EGL_HEIGHT, out height);
		}

		public void SetViewportSize(int width, int height)
		{
			GLES20.Viewport(0, 0, width, height);
		}

		public void DestroySurface()
		{
			if (eglDisplay != EGL.EGL_NO_DISPLAY && eglSurface != EGL.EGL_NO_SURFACE)
			{
				EGL.DestroySurface(eglDisplay, eglSurface);
				eglSurface = EGL.EGL_NO_SURFACE;
			}
		}

		public void MakeCurrent()
		{
			if (EGL.MakeCurrent(eglDisplay, eglSurface, eglSurface, eglContext) == false)
			{
				throw new Exception("Failed to make EGLSurface current");
			}
		}

		public bool SwapBuffers()
		{
			return EGL.SwapBuffers(eglDisplay, eglSurface) == true;
		}

		public void Reset()
		{
			Cleanup();
			Initialize();
		}

		private void Initialize()
		{
			int[] configAttributes = new[]
			{
				EGL.EGL_RED_SIZE, 8,
				EGL.EGL_GREEN_SIZE, 8,
				EGL.EGL_BLUE_SIZE, 8,
				EGL.EGL_ALPHA_SIZE, 8,
				EGL.EGL_DEPTH_SIZE, 8,
				EGL.EGL_STENCIL_SIZE, 8,
				EGL.EGL_NONE
			};

			int[] contextAttributes = new[]
			{
				EGL.EGL_CONTEXT_CLIENT_VERSION, 2,
				EGL.EGL_NONE
			};

			int[] defaultDisplayAttributes = new[]
			{
				// These are the default display attributes, used to request ANGLE's D3D11 renderer.
				// eglInitialize will only succeed with these attributes if the hardware supports D3D11 Feature Level 10_0+.
				EGLX.EGL_PLATFORM_ANGLE_TYPE_ANGLE, EGLX.EGL_PLATFORM_ANGLE_TYPE_D3D11_ANGLE,

				// EGL_ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER is an optimization that can have large performance benefits on mobile devices.
				// Its syntax is subject to change, though. Please update your Visual Studio templates if you experience compilation issues with it.
				EGLX.EGL_ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER, EGL.EGL_TRUE, 

				// EGL_PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE is an option that enables ANGLE to automatically call 
				// the IDXGIDevice3::Trim method on behalf of the application when it gets suspended. 
				// Calling IDXGIDevice3::Trim when an application is suspended is a Windows Store application certification requirement.
				EGLX.EGL_PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE, EGL.EGL_TRUE,
				EGL.EGL_NONE,
			};

			int[] fl9_3DisplayAttributes = new[]
			{
				// These can be used to request ANGLE's D3D11 renderer, with D3D11 Feature Level 9_3.
				// These attributes are used if the call to eglInitialize fails with the default display attributes.
				EGLX.EGL_PLATFORM_ANGLE_TYPE_ANGLE, EGLX.EGL_PLATFORM_ANGLE_TYPE_D3D11_ANGLE,
				EGLX.EGL_PLATFORM_ANGLE_MAX_VERSION_MAJOR_ANGLE, 9,
				EGLX.EGL_PLATFORM_ANGLE_MAX_VERSION_MINOR_ANGLE, 3,
				EGLX.EGL_ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER, EGL.EGL_TRUE,
				EGLX.EGL_PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE, EGL.EGL_TRUE,
				EGL.EGL_NONE,
			};

			int[] warpDisplayAttributes = new[]
			{
				// These attributes can be used to request D3D11 WARP.
				// They are used if eglInitialize fails with both the default display attributes and the 9_3 display attributes.
				EGLX.EGL_PLATFORM_ANGLE_TYPE_ANGLE, EGLX.EGL_PLATFORM_ANGLE_TYPE_D3D11_ANGLE,
				EGLX.EGL_PLATFORM_ANGLE_DEVICE_TYPE_ANGLE, EGLX.EGL_PLATFORM_ANGLE_DEVICE_TYPE_WARP_ANGLE,
				EGLX.EGL_ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER, EGL.EGL_TRUE,
				EGLX.EGL_PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE, EGL.EGL_TRUE,
				EGL.EGL_NONE,
			};

			EGLConfig config = IntPtr.Zero;

			//
			// To initialize the display, we make three sets of calls to eglGetPlatformDisplayEXT and eglInitialize, with varying 
			// parameters passed to eglGetPlatformDisplayEXT:
			// 1) The first calls uses "defaultDisplayAttributes" as a parameter. This corresponds to D3D11 Feature Level 10_0+.
			// 2) If eglInitialize fails for step 1 (e.g. because 10_0+ isn't supported by the default GPU), then we try again 
			//    using "fl9_3DisplayAttributes". This corresponds to D3D11 Feature Level 9_3.
			// 3) If eglInitialize fails for step 2 (e.g. because 9_3+ isn't supported by the default GPU), then we try again 
			//    using "warpDisplayAttributes".  This corresponds to D3D11 Feature Level 11_0 on WARP, a D3D11 software rasterizer.
			//

			// This tries to initialize EGL to D3D11 Feature Level 10_0+. See above comment for details.
			eglDisplay = EGLX.GetPlatformDisplayEXT(EGLX.EGL_PLATFORM_ANGLE_ANGLE, EGL.EGL_DEFAULT_DISPLAY, defaultDisplayAttributes);
			if (eglDisplay == EGL.EGL_NO_DISPLAY)
			{
				throw new Exception("Failed to get EGL display");
			}

			if (EGL.Initialize(eglDisplay, out int major, out int minor) == false)
			{
				// This tries to initialize EGL to D3D11 Feature Level 9_3, if 10_0+ is unavailable (e.g. on some mobile devices).
				eglDisplay = EGLX.GetPlatformDisplayEXT(EGLX.EGL_PLATFORM_ANGLE_ANGLE, EGL.EGL_DEFAULT_DISPLAY, fl9_3DisplayAttributes);
				if (eglDisplay == EGL.EGL_NO_DISPLAY)
				{
					throw new Exception("Failed to get EGL display");
				}

				if (EGL.Initialize(eglDisplay, out major, out minor) == false)
				{
					// This initializes EGL to D3D11 Feature Level 11_0 on WARP, if 9_3+ is unavailable on the default GPU.
					eglDisplay = EGLX.GetPlatformDisplayEXT(EGLX.EGL_PLATFORM_ANGLE_ANGLE, EGL.EGL_DEFAULT_DISPLAY, warpDisplayAttributes);
					if (eglDisplay == EGL.EGL_NO_DISPLAY)
					{
						throw new Exception("Failed to get EGL display");
					}

					if (EGL.Initialize(eglDisplay, out major, out minor) == false)
					{
						// If all of the calls to eglInitialize returned EGL_FALSE then an error has occurred.
						throw new Exception("Failed to initialize EGL");
					}
				}
			}

			EGLDisplay_ configs;
			if ((EGL.ChooseConfig(eglDisplay, configAttributes, out configs, 1, out int numConfigs) == false) || (numConfigs == 0))
			{
				throw new Exception("Failed to choose first EGLConfig");
			}
			eglConfig = configs;

			eglContext = EGL.CreateContext(eglDisplay, eglConfig, EGL.EGL_NO_CONTEXT, contextAttributes);
			if (eglContext == EGL.EGL_NO_CONTEXT)
			{
				throw new Exception("Failed to create EGL context");
			}
		}

		private void Cleanup()
		{
			if (eglDisplay != EGL.EGL_NO_DISPLAY && eglContext != EGL.EGL_NO_CONTEXT)
			{
				EGL.DestroyContext(eglDisplay, eglContext);
				eglContext = EGL.EGL_NO_CONTEXT;
			}

			if (eglDisplay != EGL.EGL_NO_DISPLAY)
			{
				EGL.Terminate(eglDisplay);
				eglDisplay = EGL.EGL_NO_DISPLAY;
			}
		}
	}
}
