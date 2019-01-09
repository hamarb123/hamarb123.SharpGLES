using System;
using System.Runtime.InteropServices;

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

	public static class EGLX
	{
		public const int EGL_EGLEXT_VERSION = 20160209;

		public const int EGL_CL_EVENT_HANDLE_KHR = 0x309C;
		public const int EGL_SYNC_CL_EVENT_KHR = 0x30FE;
		public const int EGL_SYNC_CL_EVENT_COMPLETE_KHR = 0x30FF;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATESYNC64KHRPROC) (IntPtr dpy, int type, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateSync64KHR")]
		public static extern IntPtr CreateSync64KHR(IntPtr dpy, int type, int[] attrib_list);

		public const int EGL_CONFORMANT_KHR = 0x3042;
		public const int EGL_VG_COLORSPACE_LINEAR_BIT_KHR = 0x0020;
		public const int EGL_VG_ALPHA_FORMAT_PRE_BIT_KHR = 0x0040;

		public const int EGL_CONTEXT_MAJOR_VERSION_KHR = 0x3098;
		public const int EGL_CONTEXT_MINOR_VERSION_KHR = 0x30FB;
		public const int EGL_CONTEXT_FLAGS_KHR = 0x30FC;
		public const int EGL_CONTEXT_OPENGL_PROFILE_MASK_KHR = 0x30FD;
		public const int EGL_CONTEXT_OPENGL_RESET_NOTIFICATION_STRATEGY_KHR = 0x31BD;
		public const int EGL_NO_RESET_NOTIFICATION_KHR = 0x31BE;
		public const int EGL_LOSE_CONTEXT_ON_RESET_KHR = 0x31BF;
		public const int EGL_CONTEXT_OPENGL_DEBUG_BIT_KHR = 0x00000001;
		public const int EGL_CONTEXT_OPENGL_FORWARD_COMPATIBLE_BIT_KHR = 0x00000002;
		public const int EGL_CONTEXT_OPENGL_ROBUST_ACCESS_BIT_KHR = 0x00000004;
		public const int EGL_CONTEXT_OPENGL_CORE_PROFILE_BIT_KHR = 0x00000001;
		public const int EGL_CONTEXT_OPENGL_COMPATIBILITY_PROFILE_BIT_KHR = 0x00000002;
		public const int EGL_OPENGL_ES3_BIT_KHR = 0x00000040;

		public const int EGL_CONTEXT_OPENGL_NO_ERROR_KHR = 0x31B3;

		public delegate void EGLDEBUGPROCKHR(int error, [MarshalAs(UnmanagedType.LPStr)] string command, int messageType, IntPtr threadLabel, IntPtr objectLabel, [MarshalAs(UnmanagedType.LPStr)] string message);

		public const int EGL_OBJECT_THREAD_KHR = 0x33B0;
		public const int EGL_OBJECT_DISPLAY_KHR = 0x33B1;
		public const int EGL_OBJECT_CONTEXT_KHR = 0x33B2;
		public const int EGL_OBJECT_SURFACE_KHR = 0x33B3;
		public const int EGL_OBJECT_IMAGE_KHR = 0x33B4;
		public const int EGL_OBJECT_SYNC_KHR = 0x33B5;
		public const int EGL_OBJECT_STREAM_KHR = 0x33B6;
		public const int EGL_DEBUG_MSG_CRITICAL_KHR = 0x33B9;
		public const int EGL_DEBUG_MSG_ERROR_KHR = 0x33BA;
		public const int EGL_DEBUG_MSG_WARN_KHR = 0x33BB;
		public const int EGL_DEBUG_MSG_INFO_KHR = 0x33BC;
		public const int EGL_DEBUG_CALLBACK_KHR = 0x33B8;

		//typedef int(EGLAPIENTRYP PFNEGLDEBUGMESSAGECONTROLKHRPROC) (EGLDEBUGPROCKHR callback, IntPtr[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYDEBUGKHRPROC) (int attribute, IntPtr* value);
		//typedef int(EGLAPIENTRYP PFNEGLLABELOBJECTKHRPROC) (IntPtr display, int objectType, IntPtr object, IntPtr label);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglDebugMessageControlKHR")]
		public static extern int DebugMessageControlKHR([MarshalAs(UnmanagedType.FunctionPtr)] EGLDEBUGPROCKHR callback, IntPtr[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryDebugKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryDebugKHR(int attribute, out IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglLabelObjectKHR")]
		public static extern int LabelObjectKHR(IntPtr display, int objectType, IntPtr object_, IntPtr label);

		public const int EGL_SYNC_PRIOR_COMMANDS_COMPLETE_KHR = 0x30F0;
		public const int EGL_SYNC_CONDITION_KHR = 0x30F8;
		public const int EGL_SYNC_FENCE_KHR = 0x30F9;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATESYNCKHRPROC) (IntPtr dpy, int type, int[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLDESTROYSYNCKHRPROC) (IntPtr dpy, IntPtr sync);
		//typedef int(EGLAPIENTRYP PFNEGLCLIENTWAITSYNCKHRPROC) (IntPtr dpy, IntPtr sync, int flags, ulong timeout);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLGETSYNCATTRIBKHRPROC) (IntPtr dpy, IntPtr sync, int attribute, int* value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateSyncKHR")]
		public static extern IntPtr CreateSyncKHR(IntPtr dpy, int type, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglDestroySyncKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroySyncKHR(IntPtr dpy, IntPtr sync);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglClientWaitSyncKHR")]
		public static extern int ClientWaitSyncKHR(IntPtr dpy, IntPtr sync, int flags, ulong timeout);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetSyncAttribKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetSyncAttribKHR(IntPtr dpy, IntPtr sync, int attribute, out int value);

		public const int EGL_GL_COLORSPACE_KHR = 0x309D;
		public const int EGL_GL_COLORSPACE_SRGB_KHR = 0x3089;
		public const int EGL_GL_COLORSPACE_LINEAR_KHR = 0x308A;

		public const int EGL_GL_RENDERBUFFER_KHR = 0x30B9;

		public const int EGL_GL_TEXTURE_2D_KHR = 0x30B1;
		public const int EGL_GL_TEXTURE_LEVEL_KHR = 0x30BC;
		
		public const int EGL_GL_TEXTURE_3D_KHR = 0x30B2;
		public const int EGL_GL_TEXTURE_ZOFFSET_KHR = 0x30BD;

		public const int EGL_GL_TEXTURE_CUBE_MAP_POSITIVE_X_KHR = 0x30B3;
		public const int EGL_GL_TEXTURE_CUBE_MAP_NEGATIVE_X_KHR = 0x30B4;
		public const int EGL_GL_TEXTURE_CUBE_MAP_POSITIVE_Y_KHR = 0x30B5;
		public const int EGL_GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_KHR = 0x30B6;
		public const int EGL_GL_TEXTURE_CUBE_MAP_POSITIVE_Z_KHR = 0x30B7;
		public const int EGL_GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_KHR = 0x30B8;

		public const int EGL_NATIVE_PIXMAP_KHR = 0x30B0;
		public static readonly IntPtr EGL_NO_IMAGE_KHR = (IntPtr)0;
		
		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEIMAGEKHRPROC) (IntPtr dpy, IntPtr ctx, int target, IntPtr buffer, int[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLDESTROYIMAGEKHRPROC) (IntPtr dpy, IntPtr image);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateImageKHR")]
		public static extern IntPtr CreateImageKHR(IntPtr dpy, IntPtr ctx, int target, IntPtr buffer, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglDestroyImageKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroyImageKHR(IntPtr dpy, IntPtr image);

		public const int EGL_IMAGE_PRESERVED_KHR = 0x30D2;

		public const int EGL_READ_SURFACE_BIT_KHR = 0x0001;
		public const int EGL_WRITE_SURFACE_BIT_KHR = 0x0002;
		public const int EGL_LOCK_SURFACE_BIT_KHR = 0x0080;
		public const int EGL_OPTIMAL_FORMAT_BIT_KHR = 0x0100;
		public const int EGL_MATCH_FORMAT_KHR = 0x3043;
		public const int EGL_FORMAT_RGB_565_EXACT_KHR = 0x30C0;
		public const int EGL_FORMAT_RGB_565_KHR = 0x30C1;
		public const int EGL_FORMAT_RGBA_8888_EXACT_KHR = 0x30C2;
		public const int EGL_FORMAT_RGBA_8888_KHR = 0x30C3;
		public const int EGL_MAP_PRESERVE_PIXELS_KHR = 0x30C4;
		public const int EGL_LOCK_USAGE_HINT_KHR = 0x30C5;
		public const int EGL_BITMAP_POINTER_KHR = 0x30C6;
		public const int EGL_BITMAP_PITCH_KHR = 0x30C7;
		public const int EGL_BITMAP_ORIGIN_KHR = 0x30C8;
		public const int EGL_BITMAP_PIXEL_RED_OFFSET_KHR = 0x30C9;
		public const int EGL_BITMAP_PIXEL_GREEN_OFFSET_KHR = 0x30CA;
		public const int EGL_BITMAP_PIXEL_BLUE_OFFSET_KHR = 0x30CB;
		public const int EGL_BITMAP_PIXEL_ALPHA_OFFSET_KHR = 0x30CC;
		public const int EGL_BITMAP_PIXEL_LUMINANCE_OFFSET_KHR = 0x30CD;
		public const int EGL_LOWER_LEFT_KHR = 0x30CE;
		public const int EGL_UPPER_LEFT_KHR = 0x30CF;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLLOCKSURFACEKHRPROC) (IntPtr dpy, IntPtr surface, int[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLUNLOCKSURFACEKHRPROC) (IntPtr dpy, IntPtr surface);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglLockSurfaceKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool LockSurfaceKHR(IntPtr dpy, IntPtr surface, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglUnlockSurfaceKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool UnlockSurfaceKHR(IntPtr dpy, IntPtr surface);

		public const int EGL_BITMAP_PIXEL_SIZE_KHR = 0x3110;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYSURFACE64KHRPROC) (IntPtr dpy, IntPtr surface, int attribute, IntPtr* value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQuerySurface64KHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QuerySurface64KHR(IntPtr dpy, IntPtr surface, int attribute, out IntPtr value);

		public const int EGL_BUFFER_AGE_KHR = 0x313D;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSETDAMAGEREGIONKHRPROC) (IntPtr dpy, IntPtr surface, int* rects, int n_rects);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSetDamageRegionKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SetDamageRegionKHR(IntPtr dpy, IntPtr surface,  int[] rects, int n_rects);

		public const int EGL_PLATFORM_ANDROID_KHR = 0x3141;

		public const int EGL_PLATFORM_GBM_KHR = 0x31D7;

		public const int EGL_PLATFORM_WAYLAND_KHR = 0x31D8;
		
		public const int EGL_PLATFORM_X11_KHR = 0x31D5;
		public const int EGL_PLATFORM_X11_SCREEN_KHR = 0x31D6;

		public const int EGL_SYNC_STATUS_KHR = 0x30F1;
		public const int EGL_SIGNALED_KHR = 0x30F2;
		public const int EGL_UNSIGNALED_KHR = 0x30F3;
		public const int EGL_TIMEOUT_EXPIRED_KHR = 0x30F5;
		public const int EGL_CONDITION_SATISFIED_KHR = 0x30F6;
		public const int EGL_SYNC_TYPE_KHR = 0x30F7;
		public const int EGL_SYNC_REUSABLE_KHR = 0x30FA;
		public const int EGL_SYNC_FLUSH_COMMANDS_BIT_KHR = 0x0001;
		public const ulong EGL_FOREVER_KHR = 0xFFFFFFFFFFFFFFFFul;
		public static readonly IntPtr EGL_NO_SYNC_KHR = (IntPtr)0;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSIGNALSYNCKHRPROC) (IntPtr dpy, IntPtr sync, int mode);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSignalSyncKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SignalSyncKHR(IntPtr dpy, IntPtr sync, int mode);

		public static readonly IntPtr EGL_NO_STREAM_KHR = (IntPtr)0;
		public const int EGL_CONSUMER_LATENCY_USEC_KHR = 0x3210;
		public const int EGL_PRODUCER_FRAME_KHR = 0x3212;
		public const int EGL_CONSUMER_FRAME_KHR = 0x3213;
		public const int EGL_STREAM_STATE_KHR = 0x3214;
		public const int EGL_STREAM_STATE_CREATED_KHR = 0x3215;
		public const int EGL_STREAM_STATE_CONNECTING_KHR = 0x3216;
		public const int EGL_STREAM_STATE_EMPTY_KHR = 0x3217;
		public const int EGL_STREAM_STATE_NEW_FRAME_AVAILABLE_KHR = 0x3218;
		public const int EGL_STREAM_STATE_OLD_FRAME_AVAILABLE_KHR = 0x3219;
		public const int EGL_STREAM_STATE_DISCONNECTED_KHR = 0x321A;
		public const int EGL_BAD_STREAM_KHR = 0x321B;
		public const int EGL_BAD_STATE_KHR = 0x321C;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATESTREAMKHRPROC) (IntPtr dpy, int[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLDESTROYSTREAMKHRPROC) (IntPtr dpy, IntPtr stream);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMATTRIBKHRPROC) (IntPtr dpy, IntPtr stream, int attribute, int value);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYSTREAMKHRPROC) (IntPtr dpy, IntPtr stream, int attribute, int* value);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYSTREAMU64KHRPROC) (IntPtr dpy, IntPtr stream, int attribute, ulong* value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateStreamKHR")]
		public static extern IntPtr CreateStreamKHR(IntPtr dpy, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglDestroyStreamKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroyStreamKHR(IntPtr dpy, IntPtr stream);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamAttribKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamAttribKHR(IntPtr dpy, IntPtr stream, int attribute, int value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryStreamKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryStreamKHR(IntPtr dpy, IntPtr stream, int attribute, out int value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryStreamu64KHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryStreamu64KHR(IntPtr dpy, IntPtr stream, int attribute, out ulong value);
		
		public const int EGL_CONSUMER_ACQUIRE_TIMEOUT_USEC_KHR = 0x321E;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMCONSUMERGLTEXTUREEXTERNALKHRPROC) (IntPtr dpy, IntPtr stream);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMCONSUMERACQUIREKHRPROC) (IntPtr dpy, IntPtr stream);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMCONSUMERRELEASEKHRPROC) (IntPtr dpy, IntPtr stream);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamConsumerGLTextureExternalKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamConsumerGLTextureExternalKHR(IntPtr dpy, IntPtr stream);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamConsumerAcquireKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamConsumerAcquireKHR(IntPtr dpy, IntPtr stream);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamConsumerReleaseKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamConsumerReleaseKHR(IntPtr dpy, IntPtr stream);
		
		public const int EGL_NO_FILE_DESCRIPTOR_KHR = -1;

		//typedef int(EGLAPIENTRYP PFNEGLGETSTREAMFILEDESCRIPTORKHRPROC) (IntPtr dpy, IntPtr stream);
		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATESTREAMFROMFILEDESCRIPTORKHRPROC) (IntPtr dpy, int file_descriptor);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetStreamFileDescriptorKHR")]
		public static extern int GetStreamFileDescriptorKHR(IntPtr dpy, IntPtr stream);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateStreamFromFileDescriptorKHR")]
		public static extern IntPtr CreateStreamFromFileDescriptorKHR(IntPtr dpy, int file_descriptor);
		
		public const int EGL_STREAM_FIFO_LENGTH_KHR = 0x31FC;
		public const int EGL_STREAM_TIME_NOW_KHR = 0x31FD;
		public const int EGL_STREAM_TIME_CONSUMER_KHR = 0x31FE;
		public const int EGL_STREAM_TIME_PRODUCER_KHR = 0x31FF;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYSTREAMTIMEKHRPROC) (IntPtr dpy, IntPtr stream, int attribute, ulong* value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryStreamTimeKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryStreamTimeKHR(IntPtr dpy, IntPtr stream, int attribute, out ulong value);
		
		public const int EGL_STREAM_BIT_KHR = 0x0800;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATESTREAMPRODUCERSURFACEKHRPROC) (IntPtr dpy, IntPtr config, IntPtr stream, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateStreamProducerSurfaceKHR")]
		public static extern IntPtr CreateStreamProducerSurfaceKHR(IntPtr dpy, IntPtr config, IntPtr stream, int[] attrib_list);
		
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSWAPBUFFERSWITHDAMAGEKHRPROC) (IntPtr dpy, IntPtr surface, int* rects, int n_rects);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSwapBuffersWithDamageKHR")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapBuffersWithDamageKHR(IntPtr dpy, IntPtr surface,  int[] rects, int n_rects);

		public const int EGL_VG_PARENT_IMAGE_KHR = 0x30BA;

		//typedef int(EGLAPIENTRYP PFNEGLWAITSYNCKHRPROC) (IntPtr dpy, IntPtr sync, int flags);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglWaitSyncKHR")]
		public static extern int WaitSyncKHR(IntPtr dpy, IntPtr sync, int flags);

		public delegate void EGLSetBlobFuncANDROID(IntPtr key, IntPtr keySize, IntPtr value, IntPtr valueSize);
		public delegate IntPtr EGLGetBlobFuncANDROID(IntPtr key, IntPtr keySize, IntPtr value, IntPtr valueSize);

		//typedef void (EGLAPIENTRYP PFNEGLSETBLOBCACHEFUNCSANDROIDPROC) (IntPtr dpy, EGLSetBlobFuncANDROID set, EGLGetBlobFuncANDROID get);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSetBlobCacheFuncsANDROID")]
		public static extern void SetBlobCacheFuncsANDROID(IntPtr dpy, [MarshalAs(UnmanagedType.FunctionPtr)] EGLSetBlobFuncANDROID set, [MarshalAs(UnmanagedType.FunctionPtr)] EGLGetBlobFuncANDROID get);

		public const int EGL_FRAMEBUFFER_TARGET_ANDROID = 0x3147;

		public const int EGL_NATIVE_BUFFER_ANDROID = 0x3140;

		public const int EGL_SYNC_NATIVE_FENCE_ANDROID = 0x3144;
		public const int EGL_SYNC_NATIVE_FENCE_FD_ANDROID = 0x3145;
		public const int EGL_SYNC_NATIVE_FENCE_SIGNALED_ANDROID = 0x3146;
		public const int EGL_NO_NATIVE_FENCE_FD_ANDROID = -1;

		//typedef int(EGLAPIENTRYP PFNEGLDUPNATIVEFENCEFDANDROIDPROC) (IntPtr dpy, IntPtr sync);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglDupNativeFenceFDANDROID")]
		public static extern int DupNativeFenceFDANDROID(IntPtr dpy, IntPtr sync);

		public const int EGL_RECORDABLE_ANDROID = 0x3142;

		public const int EGL_D3D_TEXTURE_2D_SHARE_HANDLE_ANGLE = 0x3200;

		public const int EGL_D3D9_DEVICE_ANGLE = 0x33A0;
		public const int EGL_D3D11_DEVICE_ANGLE = 0x33A1;

		public const int EGL_DXGI_KEYED_MUTEX_ANGLE = 0x33A2;

		public const int EGL_D3D_TEXTURE_ANGLE = 0x33A3;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYSURFACEPOINTERANGLEPROC) (IntPtr dpy, IntPtr surface, int attribute, ref IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQuerySurfacePointerANGLE")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QuerySurfacePointerANGLE(IntPtr dpy, IntPtr surface, int attribute, ref IntPtr value);

		public static readonly IntPtr EGL_SOFTWARE_DISPLAY_ANGLE = (IntPtr)(-1);

		public static readonly IntPtr EGL_D3D11_ELSE_D3D9_DISPLAY_ANGLE = (IntPtr)(-2);
		public static readonly IntPtr EGL_D3D11_ONLY_DISPLAY_ANGLE = (IntPtr)(-3);

		public const int EGL_ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER = 0x320B;
		public const int EGL_ANGLE_SURFACE_RENDER_TO_BACK_BUFFER = 0x320C;

		public const int EGL_DIRECT_COMPOSITION_ANGLE = 0x33A5;

		public const int EGL_PLATFORM_ANGLE_ANGLE = 0x3202;
		public const int EGL_PLATFORM_ANGLE_TYPE_ANGLE = 0x3203;
		public const int EGL_PLATFORM_ANGLE_MAX_VERSION_MAJOR_ANGLE = 0x3204;
		public const int EGL_PLATFORM_ANGLE_MAX_VERSION_MINOR_ANGLE = 0x3205;
		public const int EGL_PLATFORM_ANGLE_TYPE_DEFAULT_ANGLE = 0x3206;

		public const int EGL_PLATFORM_ANGLE_TYPE_D3D9_ANGLE = 0x3207;
		public const int EGL_PLATFORM_ANGLE_TYPE_D3D11_ANGLE = 0x3208;
		public const int EGL_PLATFORM_ANGLE_DEVICE_TYPE_ANGLE = 0x3209;
		public const int EGL_PLATFORM_ANGLE_DEVICE_TYPE_HARDWARE_ANGLE = 0x320A;
		public const int EGL_PLATFORM_ANGLE_DEVICE_TYPE_WARP_ANGLE = 0x320B;
		public const int EGL_PLATFORM_ANGLE_DEVICE_TYPE_REFERENCE_ANGLE = 0x320C;
		public const int EGL_PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE = 0x320F;

		public const int EGL_PLATFORM_ANGLE_TYPE_OPENGL_ANGLE = 0x320D;
		public const int EGL_PLATFORM_ANGLE_TYPE_OPENGLES_ANGLE = 0x320E;

		public const int EGL_PLATFORM_ANGLE_TYPE_NULL_ANGLE = 0x33AE;

		public const int EGL_FIXED_SIZE_ANGLE = 0x3201;

		public const int EGL_X11_VISUAL_ID_ANGLE = 0x33A3;

		public const int EGL_FLEXIBLE_SURFACE_COMPATIBILITY_SUPPORTED_ANGLE = 0x33A6;

		public const int EGL_OPTIMAL_SURFACE_ORIENTATION_ANGLE = 0x33A7;
		public const int EGL_SURFACE_ORIENTATION_ANGLE = 0x33A8;
		public const int EGL_SURFACE_ORIENTATION_INVERT_X_ANGLE = 0x0001;
		public const int EGL_SURFACE_ORIENTATION_INVERT_Y_ANGLE = 0x0002;

		public const int EGL_EXPERIMENTAL_PRESENT_PATH_ANGLE = 0x33A4;
		public const int EGL_EXPERIMENTAL_PRESENT_PATH_FAST_ANGLE = 0x33A9;
		public const int EGL_EXPERIMENTAL_PRESENT_PATH_COPY_ANGLE = 0x33AA;

		public const int EGL_D3D_TEXTURE_SUBRESOURCE_ID_ANGLE = 0x33AB;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLCREATESTREAMPRODUCERD3DTEXTURENV12ANGLEPROC)(IntPtr dpy, IntPtr stream, IntPtr[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMPOSTD3DTEXTURENV12ANGLEPROC)(IntPtr dpy, IntPtr stream, IntPtr texture, IntPtr[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateStreamProducerD3DTextureNV12ANGLE")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CreateStreamProducerD3DTextureNV12ANGLE(IntPtr dpy, IntPtr stream, IntPtr[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamPostD3DTextureNV12ANGLE")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamPostD3DTextureNV12ANGLE(IntPtr dpy, IntPtr stream, IntPtr texture, IntPtr[] attrib_list);

		public const int EGL_CONTEXT_WEBGL_COMPATIBILITY_ANGLE = 0x3AAC;

		public const int EGL_CONTEXT_BIND_GENERATES_RESOURCE_CHROMIUM = 0x3AAD;

		public const int EGL_DISCARD_SAMPLES_ARM = 0x3286;

		public const int EGL_BUFFER_AGE_EXT = 0x313D;

		public const int EGL_CONTEXT_OPENGL_ROBUST_ACCESS_EXT = 0x30BF;
		public const int EGL_CONTEXT_OPENGL_RESET_NOTIFICATION_STRATEGY_EXT = 0x3138;
		public const int EGL_NO_RESET_NOTIFICATION_EXT = 0x31BE;
		public const int EGL_LOSE_CONTEXT_ON_RESET_EXT = 0x31BF;

		public static readonly IntPtr EGL_NO_DEVICE_EXT = (IntPtr)0;
		public const int EGL_BAD_DEVICE_EXT = 0x322B;
		public const int EGL_DEVICE_EXT = 0x322C;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYDEVICEATTRIBEXTPROC) (IntPtr device, int attribute, IntPtr* value);
		//typedef [MarshalAs(UnmanagedType.LPStr)] string(EGLAPIENTRYP PFNEGLQUERYDEVICESTRINGEXTPROC) (IntPtr device, int name);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYDEVICESEXTPROC) (int max_devices, IntPtr* devices, int* num_devices);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYDISPLAYATTRIBEXTPROC) (IntPtr dpy, int attribute, IntPtr* value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryDeviceAttribEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryDeviceAttribEXT(IntPtr device, int attribute, out IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryDeviceStringEXT")]
		public static extern IntPtr QueryDeviceStringEXT(IntPtr device, int name);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryDevicesEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryDevicesEXT(int max_devices,  IntPtr devices, out int num_devices);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryDisplayAttribEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryDisplayAttribEXT(IntPtr dpy, int attribute, out IntPtr value);

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEDEVICEANGLEPROC) (int device_type, IntPtr native_device, IntPtr[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLRELEASEDEVICEANGLEPROC) (IntPtr device);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateDeviceANGLE")]
		public static extern IntPtr CreateDeviceANGLE(int device_type, IntPtr native_device, IntPtr[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglReleaseDeviceANGLE")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ReleaseDeviceANGLE(IntPtr device);

		public const int EGL_DRM_DEVICE_FILE_EXT = 0x3233;

		public const int EGL_OPENWF_DEVICE_ID_EXT = 0x3237;

		public const int EGL_LINUX_DMA_BUF_EXT = 0x3270;
		public const int EGL_LINUX_DRM_FOURCC_EXT = 0x3271;
		public const int EGL_DMA_BUF_PLANE0_FD_EXT = 0x3272;
		public const int EGL_DMA_BUF_PLANE0_OFFSET_EXT = 0x3273;
		public const int EGL_DMA_BUF_PLANE0_PITCH_EXT = 0x3274;
		public const int EGL_DMA_BUF_PLANE1_FD_EXT = 0x3275;
		public const int EGL_DMA_BUF_PLANE1_OFFSET_EXT = 0x3276;
		public const int EGL_DMA_BUF_PLANE1_PITCH_EXT = 0x3277;
		public const int EGL_DMA_BUF_PLANE2_FD_EXT = 0x3278;
		public const int EGL_DMA_BUF_PLANE2_OFFSET_EXT = 0x3279;
		public const int EGL_DMA_BUF_PLANE2_PITCH_EXT = 0x327A;
		public const int EGL_YUV_COLOR_SPACE_HINT_EXT = 0x327B;
		public const int EGL_SAMPLE_RANGE_HINT_EXT = 0x327C;
		public const int EGL_YUV_CHROMA_HORIZONTAL_SITING_HINT_EXT = 0x327D;
		public const int EGL_YUV_CHROMA_VERTICAL_SITING_HINT_EXT = 0x327E;
		public const int EGL_ITU_REC601_EXT = 0x327F;
		public const int EGL_ITU_REC709_EXT = 0x3280;
		public const int EGL_ITU_REC2020_EXT = 0x3281;
		public const int EGL_YUV_FULL_RANGE_EXT = 0x3282;
		public const int EGL_YUV_NARROW_RANGE_EXT = 0x3283;
		public const int EGL_YUV_CHROMA_SITING_0_EXT = 0x3284;
		public const int EGL_YUV_CHROMA_SITING_0_5_EXT = 0x3285;

		public const int EGL_MULTIVIEW_VIEW_COUNT_EXT = 0x3134;

		public static readonly IntPtr EGL_NO_OUTPUT_LAYER_EXT = (IntPtr)0;
		public static readonly IntPtr EGL_NO_OUTPUT_PORT_EXT = (IntPtr)0;
		public const int EGL_BAD_OUTPUT_LAYER_EXT = 0x322D;
		public const int EGL_BAD_OUTPUT_PORT_EXT = 0x322E;
		public const int EGL_SWAP_INTERVAL_EXT = 0x322F;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLGETOUTPUTLAYERSEXTPROC) (IntPtr dpy, IntPtr[] attrib_list, IntPtr *layers, int max_layers, int *num_layers);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLGETOUTPUTPORTSEXTPROC) (IntPtr dpy, IntPtr[] attrib_list, IntPtr *ports, int max_ports, int *num_ports);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLOUTPUTLAYERATTRIBEXTPROC) (IntPtr dpy, IntPtr layer, int attribute, IntPtr value);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYOUTPUTLAYERATTRIBEXTPROC) (IntPtr dpy, IntPtr layer, int attribute, IntPtr* value);
		//typedef [MarshalAs(UnmanagedType.LPStr)] string(EGLAPIENTRYP PFNEGLQUERYOUTPUTLAYERSTRINGEXTPROC) (IntPtr dpy, IntPtr layer, int name);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLOUTPUTPORTATTRIBEXTPROC) (IntPtr dpy, IntPtr port, int attribute, IntPtr value);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYOUTPUTPORTATTRIBEXTPROC) (IntPtr dpy, IntPtr port, int attribute, IntPtr* value);
		//typedef [MarshalAs(UnmanagedType.LPStr)] string(EGLAPIENTRYP PFNEGLQUERYOUTPUTPORTSTRINGEXTPROC) (IntPtr dpy, IntPtr port, int name);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetOutputLayersEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetOutputLayersEXT(IntPtr dpy, IntPtr[] attrib_list, IntPtr layers, int max_layers, out int num_layers);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetOutputPortsEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetOutputPortsEXT(IntPtr dpy, IntPtr[] attrib_list, IntPtr ports, int max_ports, out int num_ports);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglOutputLayerAttribEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool OutputLayerAttribEXT(IntPtr dpy, IntPtr layer, int attribute, IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryOutputLayerAttribEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryOutputLayerAttribEXT(IntPtr dpy, IntPtr layer, int attribute, out IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryOutputLayerStringEXT")]
		public static extern IntPtr QueryOutputLayerStringEXT(IntPtr dpy, IntPtr layer, int name);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglOutputPortAttribEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool OutputPortAttribEXT(IntPtr dpy, IntPtr port, int attribute, IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryOutputPortAttribEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryOutputPortAttribEXT(IntPtr dpy, IntPtr port, int attribute, out IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryOutputPortStringEXT")]
		public static extern IntPtr QueryOutputPortStringEXT(IntPtr dpy, IntPtr port, int name);

		public const int EGL_DRM_CRTC_EXT = 0x3234;
		public const int EGL_DRM_PLANE_EXT = 0x3235;
		public const int EGL_DRM_CONNECTOR_EXT = 0x3236;

		public const int EGL_OPENWF_PIPELINE_ID_EXT = 0x3238;
		public const int EGL_OPENWF_PORT_ID_EXT = 0x3239;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLGETPLATFORMDISPLAYEXTPROC) (int platform, IntPtr native_display, int[] attrib_list);
		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEPLATFORMWINDOWSURFACEEXTPROC) (IntPtr dpy, IntPtr config, IntPtr native_window, int[] attrib_list);
		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEPLATFORMPIXMAPSURFACEEXTPROC) (IntPtr dpy, IntPtr config, IntPtr native_pixmap, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetPlatformDisplayEXT")]
		public static extern IntPtr GetPlatformDisplayEXT(int platform, IntPtr native_display, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreatePlatformWindowSurfaceEXT")]
		public static extern IntPtr CreatePlatformWindowSurfaceEXT(IntPtr dpy, IntPtr config, IntPtr native_window, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreatePlatformPixmapSurfaceEXT")]
		public static extern IntPtr CreatePlatformPixmapSurfaceEXT(IntPtr dpy, IntPtr config, IntPtr native_pixmap, int[] attrib_list);

		public const int EGL_PLATFORM_DEVICE_EXT = 0x313F;

		public const int EGL_PLATFORM_WAYLAND_EXT = 0x31D8;

		public const int EGL_PLATFORM_X11_EXT = 0x31D5;
		public const int EGL_PLATFORM_X11_SCREEN_EXT = 0x31D6;

		public const int EGL_PROTECTED_CONTENT_EXT = 0x32C0;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMCONSUMEROUTPUTEXTPROC) (IntPtr dpy, IntPtr stream, IntPtr layer);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamConsumerOutputEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamConsumerOutputEXT(IntPtr dpy, IntPtr stream, IntPtr layer);

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSWAPBUFFERSWITHDAMAGEEXTPROC) (IntPtr dpy, IntPtr surface, int* rects, int n_rects);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSwapBuffersWithDamageEXT")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapBuffersWithDamageEXT(IntPtr dpy, IntPtr surface, int[] rects, int n_rects);

		public const int EGL_YUV_ORDER_EXT = 0x3301;
		public const int EGL_YUV_NUMBER_OF_PLANES_EXT = 0x3311;
		public const int EGL_YUV_SUBSAMPLE_EXT = 0x3312;
		public const int EGL_YUV_DEPTH_RANGE_EXT = 0x3317;
		public const int EGL_YUV_CSC_STANDARD_EXT = 0x330A;
		public const int EGL_YUV_PLANE_BPP_EXT = 0x331A;
		public const int EGL_YUV_BUFFER_EXT = 0x3300;
		public const int EGL_YUV_ORDER_YUV_EXT = 0x3302;
		public const int EGL_YUV_ORDER_YVU_EXT = 0x3303;
		public const int EGL_YUV_ORDER_YUYV_EXT = 0x3304;
		public const int EGL_YUV_ORDER_UYVY_EXT = 0x3305;
		public const int EGL_YUV_ORDER_YVYU_EXT = 0x3306;
		public const int EGL_YUV_ORDER_VYUY_EXT = 0x3307;
		public const int EGL_YUV_ORDER_AYUV_EXT = 0x3308;
		public const int EGL_YUV_SUBSAMPLE_4_2_0_EXT = 0x3313;
		public const int EGL_YUV_SUBSAMPLE_4_2_2_EXT = 0x3314;
		public const int EGL_YUV_SUBSAMPLE_4_4_4_EXT = 0x3315;
		public const int EGL_YUV_DEPTH_RANGE_LIMITED_EXT = 0x3318;
		public const int EGL_YUV_DEPTH_RANGE_FULL_EXT = 0x3319;
		public const int EGL_YUV_CSC_STANDARD_601_EXT = 0x330B;
		public const int EGL_YUV_CSC_STANDARD_709_EXT = 0x330C;
		public const int EGL_YUV_CSC_STANDARD_2020_EXT = 0x330D;
		public const int EGL_YUV_PLANE_BPP_0_EXT = 0x331B;
		public const int EGL_YUV_PLANE_BPP_8_EXT = 0x331C;
		public const int EGL_YUV_PLANE_BPP_10_EXT = 0x331D;

		public struct EGLClientPixmapHI
		{
			public IntPtr pData;
			public int iWidth;
			public int iHeight;
			public int iStride;
		}
		public const int EGL_CLIENT_PIXMAP_POINTER_HI = unchecked((short)0x8F74);

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEPIXMAPSURFACEHIPROC) (IntPtr dpy, IntPtr config, EGLClientPixmapHI *pixmap);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreatePixmapSurfaceHI")]
		public static extern IntPtr CreatePixmapSurfaceHI(IntPtr dpy, IntPtr config, EGLClientPixmapHI[] pixmap);

		public const int EGL_COLOR_FORMAT_HI = unchecked((short)0x8F70);
		public const int EGL_COLOR_RGB_HI = unchecked((short)0x8F71);
		public const int EGL_COLOR_RGBA_HI = unchecked((short)0x8F72);
		public const int EGL_COLOR_ARGB_HI = unchecked((short)0x8F73);

		public const int EGL_CONTEXT_PRIORITY_LEVEL_IMG = 0x3100;
		public const int EGL_CONTEXT_PRIORITY_HIGH_IMG = 0x3101;
		public const int EGL_CONTEXT_PRIORITY_MEDIUM_IMG = 0x3102;
		public const int EGL_CONTEXT_PRIORITY_LOW_IMG = 0x3103;

		public const int EGL_NATIVE_BUFFER_MULTIPLANE_SEPARATE_IMG = 0x3105;
		public const int EGL_NATIVE_BUFFER_PLANE_OFFSET_IMG = 0x3106;

		public const int EGL_DRM_BUFFER_FORMAT_MESA = 0x31D0;
		public const int EGL_DRM_BUFFER_USE_MESA = 0x31D1;
		public const int EGL_DRM_BUFFER_FORMAT_ARGB32_MESA = 0x31D2;
		public const int EGL_DRM_BUFFER_MESA = 0x31D3;
		public const int EGL_DRM_BUFFER_STRIDE_MESA = 0x31D4;
		public const int EGL_DRM_BUFFER_USE_SCANOUT_MESA = 0x00000001;
		public const int EGL_DRM_BUFFER_USE_SHARE_MESA = 0x00000002;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEDRMIMAGEMESAPROC) (IntPtr dpy, int[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLEXPORTDRMIMAGEMESAPROC) (IntPtr dpy, IntPtr image, int* name, int* handle, int* stride);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateDRMImageMESA")]
		public static extern IntPtr CreateDRMImageMESA(IntPtr dpy, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglExportDRMImageMESA")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ExportDRMImageMESA(IntPtr dpy, IntPtr image, out int name, out int handle, out int stride);

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLEXPORTDMABUFIMAGEQUERYMESAPROC) (IntPtr dpy, IntPtr image, int* fourcc, int* num_planes, ulong* modifiers);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLEXPORTDMABUFIMAGEMESAPROC) (IntPtr dpy, IntPtr image, int* fds, int* strides, int* offsets);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglExportDMABUFImageQueryMESA")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ExportDMABUFImageQueryMESA(IntPtr dpy, IntPtr image, out int fourcc, out int num_planes, out ulong modifiers);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglExportDMABUFImageMESA")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ExportDMABUFImageMESA(IntPtr dpy, IntPtr image, out int fds, out int strides, out int offsets);

		public const int EGL_PLATFORM_GBM_MESA = 0x31D7;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSWAPBUFFERSREGIONNOKPROC) (IntPtr dpy, IntPtr surface, int numRects, int[] rects);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSwapBuffersRegionNOK")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapBuffersRegionNOK(IntPtr dpy, IntPtr surface, int numRects, int[] rects);

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSWAPBUFFERSREGION2NOKPROC) (IntPtr dpy, IntPtr surface, int numRects, int[] rects);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSwapBuffersRegion2NOK")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapBuffersRegion2NOK(IntPtr dpy, IntPtr surface, int numRects, int[] rects);

		public const int EGL_Y_INVERTED_NOK = 0x307F;

		public const int EGL_AUTO_STEREO_NV = 0x3136;

		public const int EGL_COVERAGE_BUFFERS_NV = 0x30E0;
		public const int EGL_COVERAGE_SAMPLES_NV = 0x30E1;

		public const int EGL_COVERAGE_SAMPLE_RESOLVE_NV = 0x3131;
		public const int EGL_COVERAGE_SAMPLE_RESOLVE_DEFAULT_NV = 0x3132;
		public const int EGL_COVERAGE_SAMPLE_RESOLVE_NONE_NV = 0x3133;

		public const int EGL_CUDA_EVENT_HANDLE_NV = 0x323B;
		public const int EGL_SYNC_CUDA_EVENT_NV = 0x323C;
		public const int EGL_SYNC_CUDA_EVENT_COMPLETE_NV = 0x323D;

		public const int EGL_DEPTH_ENCODING_NV = 0x30E2;
		public const int EGL_DEPTH_ENCODING_NONE_NV = 0;
		public const int EGL_DEPTH_ENCODING_NONLINEAR_NV = 0x30E3;

		public const int EGL_CUDA_DEVICE_NV = 0x323A;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYNATIVEDISPLAYNVPROC) (IntPtr dpy, IntPtr* display_id);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYNATIVEWINDOWNVPROC) (IntPtr dpy, IntPtr surf, IntPtr* window);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYNATIVEPIXMAPNVPROC) (IntPtr dpy, IntPtr surf, IntPtr* pixmap);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryNativeDisplayNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryNativeDisplayNV(IntPtr dpy, out IntPtr display_id);

#if DESKTOP
		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryNativeWindowNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryNativeWindowNV(IntPtr dpy, IntPtr surf, out IntPtr window);
#elif WINDOWS_UWP
		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryNativeWindowNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryNativeWindowNV(IntPtr dpy, IntPtr surf, [MarshalAs(UnmanagedType.IInspectable)] out object window);
#endif

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryNativePixmapNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryNativePixmapNV(IntPtr dpy, IntPtr surf, out IntPtr pixmap);

		public const int EGL_POST_SUB_BUFFER_SUPPORTED_NV = 0x30BE;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLPOSTSUBBUFFERNVPROC) (IntPtr dpy, IntPtr surface, int x, int y, int width, int height);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglPostSubBufferNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool PostSubBufferNV(IntPtr dpy, IntPtr surface, int x, int y, int width, int height);

		public const int EGL_YUV_PLANE0_TEXTURE_UNIT_NV = 0x332C;
		public const int EGL_YUV_PLANE1_TEXTURE_UNIT_NV = 0x332D;
		public const int EGL_YUV_PLANE2_TEXTURE_UNIT_NV = 0x332E;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSTREAMCONSUMERGLTEXTUREEXTERNALATTRIBSNVPROC) (IntPtr dpy, IntPtr stream, IntPtr* attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglStreamConsumerGLTextureExternalAttribsNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool StreamConsumerGLTextureExternalAttribsNV(IntPtr dpy, IntPtr stream, IntPtr[] attrib_list);

		public const int EGL_MAX_STREAM_METADATA_BLOCKS_NV = 0x3250;
		public const int EGL_MAX_STREAM_METADATA_BLOCK_SIZE_NV = 0x3251;
		public const int EGL_MAX_STREAM_METADATA_TOTAL_SIZE_NV = 0x3252;
		public const int EGL_PRODUCER_METADATA_NV = 0x3253;
		public const int EGL_CONSUMER_METADATA_NV = 0x3254;
		public const int EGL_PENDING_METADATA_NV = 0x3328;
		public const int EGL_METADATA0_SIZE_NV = 0x3255;
		public const int EGL_METADATA1_SIZE_NV = 0x3256;
		public const int EGL_METADATA2_SIZE_NV = 0x3257;
		public const int EGL_METADATA3_SIZE_NV = 0x3258;
		public const int EGL_METADATA0_TYPE_NV = 0x3259;
		public const int EGL_METADATA1_TYPE_NV = 0x325A;
		public const int EGL_METADATA2_TYPE_NV = 0x325B;
		public const int EGL_METADATA3_TYPE_NV = 0x325C;

		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYDISPLAYATTRIBNVPROC) (IntPtr dpy, int attribute, IntPtr* value);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSETSTREAMMETADATANVPROC) (IntPtr dpy, IntPtr stream, int n, int offset, int size, const IntPtr data);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLQUERYSTREAMMETADATANVPROC) (IntPtr dpy, IntPtr stream, int name, int n, int offset, int size, IntPtr data);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryDisplayAttribNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryDisplayAttribNV(IntPtr dpy, int attribute, out IntPtr value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSetStreamMetadataNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SetStreamMetadataNV(IntPtr dpy, IntPtr stream, int n, int offset, int size, IntPtr data);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglQueryStreamMetadataNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryStreamMetadataNV(IntPtr dpy, IntPtr stream, int name, int n, int offset, int size, IntPtr data);

		public const int EGL_SYNC_NEW_FRAME_NV = 0x321F;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATESTREAMSYNCNVPROC) (IntPtr dpy, IntPtr stream, int type, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateStreamSyncNV")]
		public static extern IntPtr CreateStreamSyncNV(IntPtr dpy, IntPtr stream, int type, int[] attrib_list);

		public const int EGL_SYNC_PRIOR_COMMANDS_COMPLETE_NV = 0x30E6;
		public const int EGL_SYNC_STATUS_NV = 0x30E7;
		public const int EGL_SIGNALED_NV = 0x30E8;
		public const int EGL_UNSIGNALED_NV = 0x30E9;
		public const int EGL_SYNC_FLUSH_COMMANDS_BIT_NV = 0x0001;
		public const ulong EGL_FOREVER_NV = 0xFFFFFFFFFFFFFFFFul;
		public const int EGL_ALREADY_SIGNALED_NV = 0x30EA;
		public const int EGL_TIMEOUT_EXPIRED_NV = 0x30EB;
		public const int EGL_CONDITION_SATISFIED_NV = 0x30EC;
		public const int EGL_SYNC_TYPE_NV = 0x30ED;
		public const int EGL_SYNC_CONDITION_NV = 0x30EE;
		public const int EGL_SYNC_FENCE_NV = 0x30EF;
		public static readonly IntPtr EGL_NO_SYNC_NV = (IntPtr)0;

		//typedef IntPtr(EGLAPIENTRYP PFNEGLCREATEFENCESYNCNVPROC) (IntPtr dpy, int condition, int[] attrib_list);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLDESTROYSYNCNVPROC) (IntPtr sync);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLFENCENVPROC) (IntPtr sync);
		//typedef int(EGLAPIENTRYP PFNEGLCLIENTWAITSYNCNVPROC) (IntPtr sync, int flags, ulong timeout);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLSIGNALSYNCNVPROC) (IntPtr sync, int mode);
		//typedef [MarshalAs(UnmanagedType.I1)] bool(EGLAPIENTRYP PFNEGLGETSYNCATTRIBNVPROC) (IntPtr sync, int attribute, int* value);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglCreateFenceSyncNV")]
		public static extern IntPtr CreateFenceSyncNV(IntPtr dpy, int condition, int[] attrib_list);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglDestroySyncNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroySyncNV(IntPtr sync);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglFenceNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool FenceNV(IntPtr sync);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglClientWaitSyncNV")]
		public static extern int ClientWaitSyncNV(IntPtr sync, int flags, ulong timeout);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglSignalSyncNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SignalSyncNV(IntPtr sync, int mode);

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetSyncAttribNV")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetSyncAttribNV(IntPtr sync, int attribute, out int value);

		//typedef ulong(EGLAPIENTRYP PFNEGLGETSYSTEMTIMEFREQUENCYNVPROC) ();
		//typedef ulong(EGLAPIENTRYP PFNEGLGETSYSTEMTIMENVPROC) ();

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetSystemTimeFrequencyNV")]
		public static extern ulong GetSystemTimeFrequencyNV();

		[DllImport(EGL.Path, ExactSpelling = true, EntryPoint = "eglGetSystemTimeNV")]
		public static extern ulong GetSystemTimeNV();

		public const int EGL_NATIVE_BUFFER_TIZEN = 0x32A0;

		public const int EGL_NATIVE_SURFACE_TIZEN = 0x32A1;
	}
}
