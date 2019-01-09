using System;
using System.Runtime.InteropServices;
#if WINDOWS_UWP
using Windows.Foundation.Collections;
#endif

namespace hamarb123.SharpGLES
{
	// Copyright (C) 2002-2013 The ANGLE Project Authors. 
	// Portions Copyright (C) Microsoft Corporation.
	//
	// BSD License
	//
	// All rights reserved.
	//
	// Redistribution and use in source and binary forms, with or without
	// modification, are permitted provided that the following conditions
	// are met:
	//
	//     Redistributions of source code must retain the above copyright
	//     notice, this list of conditions and the following disclaimer.
	//
	//     Redistributions in binary form must reproduce the above 
	//     copyright notice, this list of conditions and the following
	//     disclaimer in the documentation and/or other materials provided
	//     with the distribution.
	//
	//     Neither the name of TransGaming Inc., Google Inc., 3DLabs Inc.
	//     Ltd., Microsoft Corporation, nor the names of their contributors
	//     may be used to endorse or promote products derived from this
	//     software without specific prior written permission.
	//
	// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
	// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
	// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
	// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
	// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
	// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
	// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
	// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
	// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
	// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
	// POSSIBILITY OF SUCH DAMAGE.
	//
	// Modified by Hamish Arblaster

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

	public static class EGL
	{
		internal const string Path = @"libEGL.dll";

		//v1.0
		public const int EGL_ALPHA_SIZE = 0x3021;
		public const int EGL_BAD_ACCESS = 0x3002;
		public const int EGL_BAD_ALLOC = 0x3003;
		public const int EGL_BAD_ATTRIBUTE = 0x3004;
		public const int EGL_BAD_CONFIG = 0x3005;
		public const int EGL_BAD_CONTEXT = 0x3006;
		public const int EGL_BAD_CURRENT_SURFACE = 0x3007;
		public const int EGL_BAD_DISPLAY = 0x3008;
		public const int EGL_BAD_MATCH = 0x3009;
		public const int EGL_BAD_NATIVE_PIXMAP = 0x300A;
		public const int EGL_BAD_NATIVE_WINDOW = 0x300B;
		public const int EGL_BAD_PARAMETER = 0x300C;
		public const int EGL_BAD_SURFACE = 0x300D;
		public const int EGL_BLUE_SIZE = 0x3022;
		public const int EGL_BUFFER_SIZE = 0x3020;
		public const int EGL_CONFIG_CAVEAT = 0x3027;
		public const int EGL_CONFIG_ID = 0x3028;
		public const int EGL_CORE_NATIVE_ENGINE = 0x305B;
		public const int EGL_DEPTH_SIZE = 0x3025;
		public const int EGL_DONT_CARE = -1;
		public const int EGL_DRAW = 0x3059;
		public const int EGL_EXTENSIONS = 0x3055;
		public const int EGL_FALSE = 0;
		public const int EGL_GREEN_SIZE = 0x3023;
		public const int EGL_HEIGHT = 0x3056;
		public const int EGL_LARGEST_PBUFFER = 0x3058;
		public const int EGL_LEVEL = 0x3029;
		public const int EGL_MAX_PBUFFER_HEIGHT = 0x302A;
		public const int EGL_MAX_PBUFFER_PIXELS = 0x302B;
		public const int EGL_MAX_PBUFFER_WIDTH = 0x302C;
		public const int EGL_NATIVE_RENDERABLE = 0x302D;
		public const int EGL_NATIVE_VISUAL_ID = 0x302E;
		public const int EGL_NATIVE_VISUAL_TYPE = 0x302F;
		public const int EGL_NONE = 0x3038;
		public const int EGL_NON_CONFORMANT_CONFIG = 0x3051;
		public const int EGL_NOT_INITIALIZED = 0x3001;
		public static readonly IntPtr EGL_NO_CONTEXT = IntPtr.Zero;
		public static readonly IntPtr EGL_NO_DISPLAY = IntPtr.Zero;
		public static readonly IntPtr EGL_NO_SURFACE = IntPtr.Zero;
		public const int EGL_PBUFFER_BIT = 0x0001;
		public const int EGL_PIXMAP_BIT = 0x0002;
		public const int EGL_READ = 0x305A;
		public const int EGL_RED_SIZE = 0x3024;
		public const int EGL_SAMPLES = 0x3031;
		public const int EGL_SAMPLE_BUFFERS = 0x3032;
		public const int EGL_SLOW_CONFIG = 0x3050;
		public const int EGL_STENCIL_SIZE = 0x3026;
		public const int EGL_SUCCESS = 0x3000;
		public const int EGL_SURFACE_TYPE = 0x3033;
		public const int EGL_TRANSPARENT_BLUE_VALUE = 0x3035;
		public const int EGL_TRANSPARENT_GREEN_VALUE = 0x3036;
		public const int EGL_TRANSPARENT_RED_VALUE = 0x3037;
		public const int EGL_TRANSPARENT_RGB = 0x3052;
		public const int EGL_TRANSPARENT_TYPE = 0x3034;
		public const int EGL_TRUE = 1;
		public const int EGL_VENDOR = 0x3053;
		public const int EGL_VERSION = 0x3054;
		public const int EGL_WIDTH = 0x3057;
		public const int EGL_WINDOW_BIT = 0x000;

		[DllImport(Path, EntryPoint = "eglChooseConfig", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ChooseConfig(IntPtr dpy, int[] attribList, out IntPtr configs, int configSize, out int numConfig);

		[DllImport(Path, EntryPoint = "eglCopyBuffers", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CopyBuffers(IntPtr dpy, IntPtr surface, IntPtr target);

		[DllImport(Path, EntryPoint = "eglCreateContext", ExactSpelling = true)]
		public static extern IntPtr CreateContext(IntPtr dpy, IntPtr config, IntPtr share_context, int[] attribList);

		[DllImport(Path, EntryPoint = "eglCreatePbufferSurface", ExactSpelling = true)]
		public static extern IntPtr CreatePbufferSurface(IntPtr dpy, IntPtr config, int[] attribList);

		[DllImport(Path, EntryPoint = "eglCreatePixmapSurface", ExactSpelling = true)]
		public static extern IntPtr CreatePixmapSurface(IntPtr dpy, IntPtr config, IntPtr pixmap, int[] attribList);

#if DESKTOP
		[DllImport(Path, EntryPoint = "eglCreateWindowSurface", ExactSpelling = true)]
		public static extern IntPtr CreateWindowSurface(IntPtr dpy, IntPtr config, IntPtr win, int[] attribList);
#elif WINDOWS_UWP
		[DllImport(Path, EntryPoint = "eglCreateWindowSurface", ExactSpelling = true)]
		public static extern IntPtr CreateWindowSurface(IntPtr dpy, IntPtr config, [MarshalAs(UnmanagedType.IInspectable)] object win, int[] attrib_list);
#endif

		[DllImport(Path, EntryPoint = "eglDestroyContext", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroyContext(IntPtr dpy, IntPtr ctx);

		[DllImport(Path, EntryPoint = "eglDestroySurface", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroySurface(IntPtr dpy, IntPtr surface);

		[DllImport(Path, EntryPoint = "eglGetConfigAttrib", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetConfigAttrib (IntPtr dpy, IntPtr config, int attribute, out int value);
		
		/// <param name="configs">This is a pointer to the config array</param>
		[DllImport(Path, EntryPoint = "eglGetConfigs", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetConfigs (IntPtr dpy, IntPtr configs, int config_size, out int num_config);

		[DllImport(Path, EntryPoint = "eglGetCurrentDisplay", ExactSpelling = true)]
		public static extern IntPtr GetCurrentDisplay ();

		[DllImport(Path, EntryPoint = "eglGetCurrentSurface", ExactSpelling = true)]
		public static extern IntPtr GetCurrentSurface (int readdraw);

		[DllImport(Path, EntryPoint = "eglGetDisplay", ExactSpelling = true)]
		public static extern IntPtr GetDisplay(IntPtr display_id);

		[DllImport(Path, EntryPoint = "eglGetError", ExactSpelling = true)]
		public static extern int GetError();

		[DllImport(Path, EntryPoint = "eglGetProcAddress", ExactSpelling = true)]
		public static extern IntPtr GetProcAddress ([MarshalAs(UnmanagedType.LPStr)] string procname);

		[DllImport(Path, EntryPoint = "eglInitialize", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Initialize(IntPtr dpy, out int major, out int minor);

		[DllImport(Path, EntryPoint = "eglMakeCurrent", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool MakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);

		[DllImport(Path, EntryPoint = "eglQueryContext", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryContext (IntPtr dpy, IntPtr ctx, int attribute, out int value);

		[DllImport(Path, EntryPoint = "eglQueryString", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern string QueryString (IntPtr dpy, int name);

		[DllImport(Path, EntryPoint = "eglQuerySurface", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QuerySurface (IntPtr dpy, IntPtr surface, int attribute, out int value);

		[DllImport(Path, EntryPoint = "eglSwapBuffers", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapBuffers(IntPtr dpy, IntPtr surface);

		[DllImport(Path, EntryPoint = "eglTerminate", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Terminate(IntPtr dpy);

		[DllImport(Path, EntryPoint = "eglWaitGL", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitGL();

		[DllImport(Path, EntryPoint = "eglWaitNative", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitNative(int engine);

		//v1.1
		public const int EGL_BACK_BUFFER = 0x3084;
		public const int EGL_BIND_TO_TEXTURE_RGB = 0x3039;
		public const int EGL_BIND_TO_TEXTURE_RGBA = 0x303A;
		public const int EGL_CONTEXT_LOST = 0x300E;
		public const int EGL_MIN_SWAP_INTERVAL = 0x303B;
		public const int EGL_MAX_SWAP_INTERVAL = 0x303C;
		public const int EGL_MIPMAP_TEXTURE = 0x3082;
		public const int EGL_MIPMAP_LEVEL = 0x3083;
		public const int EGL_NO_TEXTURE = 0x305C;
		public const int EGL_TEXTURE_2D = 0x305F;
		public const int EGL_TEXTURE_FORMAT = 0x3080;
		public const int EGL_TEXTURE_RGB = 0x305D;
		public const int EGL_TEXTURE_RGBA = 0x305E;
		public const int EGL_TEXTURE_TARGET = 0x308;

		[DllImport(Path, EntryPoint = "eglBindTexImage", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BindTexImage(IntPtr dpy, IntPtr surface, int buffer);

		[DllImport(Path, EntryPoint = "eglReleaseTexImage", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ReleaseTexImage(IntPtr dpy, IntPtr surface, int buffer);

		[DllImport(Path, EntryPoint = "eglSurfaceAttrib", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SurfaceAttrib(IntPtr dpy, IntPtr surface, int attribute, int value);

		[DllImport(Path, EntryPoint = "eglSwapInterval", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapInterval(IntPtr dpy, int interval);

		//v1.2
		public const int EGL_ALPHA_FORMAT = 0x3088;
		public const int EGL_ALPHA_FORMAT_NONPRE = 0x308B;
		public const int EGL_ALPHA_FORMAT_PRE = 0x308C;
		public const int EGL_ALPHA_MASK_SIZE = 0x303E;
		public const int EGL_BUFFER_PRESERVED = 0x3094;
		public const int EGL_BUFFER_DESTROYED = 0x3095;
		public const int EGL_CLIENT_APIS = 0x308D;
		public const int EGL_COLORSPACE = 0x3087;
		public const int EGL_COLORSPACE_sRGB = 0x3089;
		public const int EGL_COLORSPACE_LINEAR = 0x308A;
		public const int EGL_COLOR_BUFFER_TYPE = 0x303F;
		public const int EGL_CONTEXT_CLIENT_TYPE = 0x3097;
		public const int EGL_DISPLAY_SCALING = 10000;
		public const int EGL_HORIZONTAL_RESOLUTION = 0x3090;
		public const int EGL_LUMINANCE_BUFFER = 0x308F;
		public const int EGL_LUMINANCE_SIZE = 0x303D;
		public const int EGL_OPENGL_ES_BIT = 0x0001;
		public const int EGL_OPENVG_BIT = 0x0002;
		public const int EGL_OPENGL_ES_API = 0x30A0;
		public const int EGL_OPENVG_API = 0x30A1;
		public const int EGL_OPENVG_IMAGE = 0x3096;
		public const int EGL_PIXEL_ASPECT_RATIO = 0x3092;
		public const int EGL_RENDERABLE_TYPE = 0x3040;
		public const int EGL_RENDER_BUFFER = 0x3086;
		public const int EGL_RGB_BUFFER = 0x308E;
		public const int EGL_SINGLE_BUFFER = 0x3085;
		public const int EGL_SWAP_BEHAVIOR = 0x3093;
		public const int EGL_UNKNOWN = -1;
		public const int EGL_VERTICAL_RESOLUTION = 0x3091;

		[DllImport(Path, EntryPoint = "eglBindAPI", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BindAPI(uint api);

		[DllImport(Path, EntryPoint = "eglQueryAPI", ExactSpelling = true)]
		public static extern int QueryAPI();

		[DllImport(Path, EntryPoint = "eglCreatePbufferFromClientBuffer", ExactSpelling = true)]
		public static extern IntPtr CreatePbufferFromClientBuffer(IntPtr dpy, int buftype, IntPtr buffer, IntPtr config, int[] attribList);

		[DllImport(Path, EntryPoint = "eglReleaseThread", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ReleaseThread();

		[DllImport(Path, EntryPoint = "eglWaitClient", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitClient();

		//v1.3
		public const int EGL_CONFORMANT = 0x3042;
		public const int EGL_CONTEXT_CLIENT_VERSION = 0x3098;
		public const int EGL_MATCH_NATIVE_PIXMAP = 0x3041;
		public const int EGL_OPENGL_ES2_BIT = 0x0004;
		public const int EGL_VG_ALPHA_FORMAT = 0x3088;
		public const int EGL_VG_ALPHA_FORMAT_NONPRE = 0x308B;
		public const int EGL_VG_ALPHA_FORMAT_PRE = 0x308C;
		public const int EGL_VG_ALPHA_FORMAT_PRE_BIT = 0x0040;
		public const int EGL_VG_COLORSPACE = 0x3087;
		public const int EGL_VG_COLORSPACE_sRGB = 0x3089;
		public const int EGL_VG_COLORSPACE_LINEAR = 0x308A;
		public const int EGL_VG_COLORSPACE_LINEAR_BIT = 0x0020;

		//v1.4
		public static readonly IntPtr EGL_DEFAULT_DISPLAY = (IntPtr)0;
		public const int EGL_MULTISAMPLE_RESOLVE_BOX_BIT = 0x0200;
		public const int EGL_MULTISAMPLE_RESOLVE = 0x3099;
		public const int EGL_MULTISAMPLE_RESOLVE_DEFAULT = 0x309A;
		public const int EGL_MULTISAMPLE_RESOLVE_BOX = 0x309B;
		public const int EGL_OPENGL_API = 0x30A2;
		public const int EGL_OPENGL_BIT = 0x0008;
		public const int EGL_SWAP_BEHAVIOR_PRESERVED_BIT = 0x0400;

		[DllImport(Path, EntryPoint = "eglGetCurrentContext", ExactSpelling = true)]
		public static extern IntPtr GetCurrentContext();

		//v1.5
		public const int EGL_CONTEXT_MAJOR_VERSION = 0x3098;
		public const int EGL_CONTEXT_MINOR_VERSION = 0x30FB;
		public const int EGL_CONTEXT_OPENGL_PROFILE_MASK = 0x30FD;
		public const int EGL_CONTEXT_OPENGL_RESET_NOTIFICATION_STRATEGY = 0x31BD;
		public const int EGL_NO_RESET_NOTIFICATION = 0x31BE;
		public const int EGL_LOSE_CONTEXT_ON_RESET = 0x31BF;
		public const int EGL_CONTEXT_OPENGL_CORE_PROFILE_BIT = 0x00000001;
		public const int EGL_CONTEXT_OPENGL_COMPATIBILITY_PROFILE_BIT = 0x00000002;
		public const int EGL_CONTEXT_OPENGL_DEBUG = 0x31B0;
		public const int EGL_CONTEXT_OPENGL_FORWARD_COMPATIBLE = 0x31B1;
		public const int EGL_CONTEXT_OPENGL_ROBUST_ACCESS = 0x31B2;
		public const int EGL_OPENGL_ES3_BIT = 0x00000040;
		public const int EGL_CL_EVENT_HANDLE = 0x309C;
		public const int EGL_SYNC_CL_EVENT = 0x30FE;
		public const int EGL_SYNC_CL_EVENT_COMPLETE = 0x30FF;
		public const int EGL_SYNC_PRIOR_COMMANDS_COMPLETE = 0x30F0;
		public const int EGL_SYNC_TYPE = 0x30F7;
		public const int EGL_SYNC_STATUS = 0x30F1;
		public const int EGL_SYNC_CONDITION = 0x30F8;
		public const int EGL_SIGNALED = 0x30F2;
		public const int EGL_UNSIGNALED = 0x30F3;
		public const int EGL_SYNC_FLUSH_COMMANDS_BIT = 0x0001;
		public const int EGL_FOREVER = -1;
		public const int EGL_TIMEOUT_EXPIRED = 0x30F5;
		public const int EGL_CONDITION_SATISFIED = 0x30F6;
		public const int EGL_NO_SYNC = 0;
		public const int EGL_SYNC_FENCE = 0x30F9;
		public const int EGL_GL_COLORSPACE = 0x309D;
		public const int EGL_GL_COLORSPACE_SRGB = 0x3089;
		public const int EGL_GL_COLORSPACE_LINEAR = 0x308A;
		public const int EGL_GL_RENDERBUFFER = 0x30B9;
		public const int EGL_GL_TEXTURE_2D = 0x30B1;
		public const int EGL_GL_TEXTURE_LEVEL = 0x30BC;
		public const int EGL_GL_TEXTURE_3D = 0x30B2;
		public const int EGL_GL_TEXTURE_ZOFFSET = 0x30BD;
		public const int EGL_GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x30B3;
		public const int EGL_GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x30B4;
		public const int EGL_GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x30B5;
		public const int EGL_GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x30B6;
		public const int EGL_GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x30B7;
		public const int EGL_GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x30B8;
		public const int EGL_IMAGE_PRESERVED = 0x30D2;
		public const int EGL_NO_IMAGE = 0;

		[DllImport(Path, EntryPoint = "eglCreateSync", ExactSpelling = true)]
		public static extern IntPtr CreateSync(IntPtr dpy, int type, int[] attribList);

		[DllImport(Path, EntryPoint = "eglDestroySync", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroySync(IntPtr dpy, IntPtr sync);

		[DllImport(Path, EntryPoint = "eglClientWaitSync", ExactSpelling = true)]
		public static extern int ClientWaitSync(IntPtr dpy, IntPtr sync, int flags, ulong timeout);

		[DllImport(Path, EntryPoint = "eglGetSyncAttrib", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetSyncAttrib(IntPtr dpy, IntPtr sync, int attribute, out int value);

		[DllImport(Path, EntryPoint = "eglGetPlatformDisplay", ExactSpelling = true)]
		public static extern IntPtr GetPlatformDisplay(int platform, IntPtr native_display, int[] attribList);

		[DllImport(Path, EntryPoint = "eglCreatePlatformWindowSurface", ExactSpelling = true)]
		public static extern IntPtr CreatePlatformWindowSurface(IntPtr dpy, IntPtr config, IntPtr native_window, int[] attribList);

		[DllImport(Path, EntryPoint = "eglCreatePlatformPixmapSurface", ExactSpelling = true)]
		public static extern IntPtr CreatePlatformPixmapSurface(IntPtr dpy, IntPtr config, IntPtr native_pixmap, int[] attribList);

		[DllImport(Path, EntryPoint = "eglWaitSync", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitSync(IntPtr dpy, IntPtr sync, int flags);

		public static IntPtr EGL_D3D11_ONLY_DISPLAY_ANGLE = (IntPtr)(-3);

		static EGL()
		{
			LibrariesExtractor.Extract();
		}
	}
}
