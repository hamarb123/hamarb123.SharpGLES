using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace hamarb123.SharpGLES
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

	internal static class PropertySetExtensions
	{
		internal const string libInterop = "SkiaSharp.Views.Interop.UWP.dll";

		public static void AddSingle(this PropertySet properties, string key, float value)
		{
			PropertySet_AddSingle(properties, key, value);
		}

		public static void AddSize(this PropertySet properties, string key, Size size)
		{
			PropertySet_AddSize(properties, key, (float)size.Width, (float)size.Height);
		}

		public static void AddSize(this PropertySet properties, string key, float width, float height)
		{
			PropertySet_AddSize(properties, key, width, height);
		}

		[DllImport(libInterop, ExactSpelling = true)]
		private static extern void PropertySet_AddSingle([MarshalAs(UnmanagedType.IInspectable)] object properties, [MarshalAs(UnmanagedType.HString)] string key, float value);

		[DllImport(libInterop, ExactSpelling = true)]
		private static extern void PropertySet_AddSize([MarshalAs(UnmanagedType.IInspectable)] object properties, [MarshalAs(UnmanagedType.HString)] string key, float width, float height);
	}
}
