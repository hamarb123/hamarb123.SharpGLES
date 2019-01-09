using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hamarb123.SharpGLES
{
	// MIT License
	// 
	// Copyright(c) 2012 Keith Wood
	// 
	// Permission is hereby granted, free of charge, to any person obtaining a copy
	// of this software and associated documentation files (the "Software"), to deal
	// in the Software without restriction, including without limitation the rights
	// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	// copies of the Software, and to permit persons to whom the Software is
	// furnished to do so, subject to the following conditions:
	// 
	// The above copyright notice and this permission notice shall be included in all
	// copies or substantial portions of the Software.
	// 
	// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	// SOFTWARE.
	//
	// Modified by Hamish Arblaster

	public partial class GLESControl : UserControl
	{
		private EGLDisplay _display;

		public GLESControl()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			GLES20.Viewport(0, 0, Width, Height);

			OnRender?.Invoke(this, new EventArgs());

			_display.SwapBuffers();

			Invalidate();
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

		protected override void OnHandleDestroyed(EventArgs e)
		{
			OnDestroy?.Invoke();
			OnCreate = null;
			OnDestroy = null;
			DoneOnCreate = false;

			_display.Dispose();

			base.OnHandleDestroyed(e);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);

			_display = new EGLDisplay(Handle);

			DoneOnCreate = true;
			OnCreate?.Invoke();
		}

		public void OnResize()
		{
			Refresh();
		}
	}
}
