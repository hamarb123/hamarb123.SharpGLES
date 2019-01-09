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
