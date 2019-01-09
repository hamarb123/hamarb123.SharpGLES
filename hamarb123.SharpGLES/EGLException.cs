using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamarb123.SharpGLES
{
	public class EGLException : Exception
	{
		public EGLException(string message)
			: base(message)
		{

		}
	}
}
