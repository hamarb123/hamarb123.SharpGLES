using System;

namespace hamarb123.SharpGLES

	public class EGLDisplay : IDisposable
	{
		private IntPtr _nativeDisplay;
		private IntPtr _display;
		private IntPtr _surface;
		private IntPtr _context;
		private IntPtr _handle;

		public EGLDisplay(IntPtr handle)
		{
			_handle = handle;

			InitializeWindow();
			InitializeEL();
		}

		public void Dispose()
		{
			EGL.Terminate(_display);

			EGL.DestroySurface(_display, _surface);

			EGL.DestroyContext(_display, _context);

			EGLDC.ReleaseDC(_handle, _nativeDisplay);
		}

		public void SwapBuffers()
		{
			EGL.SwapBuffers(_display, _surface);
		}

		private void InitializeWindow()
		{
			_nativeDisplay = EGLDC.GetDC(_handle);

			IntPtr requestedRenderer = _nativeDisplay;

			/*if (requestedRenderer == RENDERER_D3D11)
			{
				requestedRenderer = Hook.EGL_D3D11_ONLY_DISPLAY_ANGLE;
			}*/

			_display = EGL.GetDisplay(requestedRenderer);

			int minor;
			int major;

			if (!EGL.Initialize(_display, out major, out minor))
			{
				throw new EGLException("Initialize failed.");
			}

			if (!EGL.BindAPI(EGL.EGL_OPENGL_ES_API))
			{
				throw new EGLException("BindAPI failed.");
			}
		}

		private void InitializeEL()
		{
			int[] configAttributes =
			{
				EGL.EGL_RED_SIZE, 8,
				EGL.EGL_GREEN_SIZE, 8,
				EGL.EGL_BLUE_SIZE, 8,
				EGL.EGL_ALPHA_SIZE, 8,
				EGL.EGL_DEPTH_SIZE, 24,
				EGL.EGL_STENCIL_SIZE, 8,
				EGL.EGL_SAMPLE_BUFFERS, EGL.EGL_DONT_CARE,
				EGL.EGL_NONE
			};

			int configCount;
			IntPtr configs;

			if (!EGL.ChooseConfig(_display, configAttributes, out configs, 1, out configCount))
			{
				throw new EGLException("ChooseConfig failed.");
			}

			int[] surfaceAttributes =
			{
				EGLX.EGL_POST_SUB_BUFFER_SUPPORTED_NV, EGL.EGL_TRUE, EGL.EGL_NONE, EGL.EGL_NONE
			};

			_surface = EGL.CreateWindowSurface(_display, configs, _handle, surfaceAttributes);

			int[] contextAttibutes =
			{
				EGL.EGL_CONTEXT_CLIENT_VERSION, 2, EGL.EGL_NONE
			};

			_context = EGL.CreateContext(_display, configs, IntPtr.Zero, contextAttibutes);

			EGL.MakeCurrent(_display, _surface, _surface, _context);

			EGL.SwapInterval(_display, 0);
		}
	}
}
