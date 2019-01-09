using System;
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

	public class GLBuffer<T>
		where T : new()
	{
		private T[] _buffer;
		private GCHandle _handle;
		private IntPtr _address;
		private bool _disposed;
		private int _position;
		private int _stride;
		public int capacity;

		public GLBuffer(int capacity)
		{
			this.capacity = capacity;

			_buffer = new T[capacity];

			_handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);

			_address = _handle.AddrOfPinnedObject();

			_stride = Marshal.SizeOf<T>();
		}

		public void Position(int position)
		{
			_position = position;
		}

		public static implicit operator IntPtr(GLBuffer<T> array)
		{
			return IntPtr.Add(array._address, array._position * array._stride);
		}

		public void Put(T[] data, int offset, int length)
		{
			Array.Copy(data, _position, _buffer, offset, length);

			_position += length;
		}

		public void Put(T[] data)
		{
			Put(data, _position, data.Length);

			_position += data.Length;
		}

		public int Limit()
		{
			return capacity - _position;
		}

		public T this[int index]
		{
			get
			{
				return _buffer[index];
			}
			set
			{
				_buffer[index] = value;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				_disposed = true;

				_handle.Free();
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~GLBuffer()
		{
			Dispose(false);
		}
	}
}
