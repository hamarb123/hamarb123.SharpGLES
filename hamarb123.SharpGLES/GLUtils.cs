using System;
#if DESKTOP
using System.Drawing;
using System.Drawing.Imaging;
#endif
using System.Runtime.InteropServices;

namespace hamarb123.SharpGLES
{
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
