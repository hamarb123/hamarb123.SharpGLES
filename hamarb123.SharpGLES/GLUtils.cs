using System;
#if DESKTOP
using System.Drawing;
using System.Drawing.Imaging;
#endif
using System.Runtime.InteropServices;

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
	
	public static class GLUtils
	{
#if DESKTOP
		public static void TexImage2D(int target, int level, Image image, int border)
		{
			PixelFormat format = PixelFormat.Format32bppArgb;

			Bitmap bitmap = new Bitmap(image.Width, image.Height, format);

			Graphics graphics = Graphics.FromImage(bitmap);

			graphics.DrawImage(image, 0, 0, image.Width, image.Height);

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, format);

			int size = data.Stride * data.Height;

			byte[] buffer = new byte[size];

			Marshal.Copy(data.Scan0, buffer, 0, size);

			bitmap.UnlockBits(data);

			bitmap.Dispose();

			TexImage2D(target, level, buffer, image.Width, border);
		}
#endif
		//TODO: WINDOWS_UWP

		public static void TexImage2D(int target, int level, byte[] byteDataBGRA, int width, int border)
		{
			byte[] buffer = byteDataBGRA;
			
			for (int i = 0; i < buffer.Length; i += 4)
			{
				byte b = buffer[i];
				byte r = buffer[i + 2];

				buffer[i] = r;
				buffer[i + 2] = b;
			}

			TexImage2DRGBA(target, level, buffer, width, border);
		}
		
		public static void TexImage2DRGBA(int target, int level, byte[] byteDataRGBA, int width, int border)
		{
			byte[] buffer = byteDataRGBA;
			
			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

			IntPtr address = handle.AddrOfPinnedObject();

			GLES20.TexImage2D(target, level, GLES20.GL_RGBA, width, byteDataRGBA.Length / width / 4, border, GLES20.GL_RGBA, GLES20.GL_UNSIGNED_BYTE, address);

			handle.Free();
		}
	}
}
