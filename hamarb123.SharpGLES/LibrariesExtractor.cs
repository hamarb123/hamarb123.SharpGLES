using System;
using System.Collections.Generic;
#if DESKTOP
using System.IO;
using System.Reflection;
#endif
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace hamarb123.SharpGLES
{
	internal static class LibrariesExtractor
	{
#if DESKTOP
		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string dllToLoad);
#elif WINDOWS_UWP
		[DllImport("kernel32.DLL", SetLastError = true)]
		public static extern IntPtr LoadPackagedLibrary([MarshalAs(UnmanagedType.LPWStr)] string libraryName, int reserved = 0);
#endif

		private static bool Done = false;
		private static object o = new object();

		internal static void Extract()
		{
			lock (o)
			{
				if (Done)
				{
					return;
				}
#if DESKTOP
#if x64
#if DEBUG
				LoadLibraries(LibrariesDesktopX64Debug.libEGL, LibrariesDesktopX64Debug.libGLESv2, LibrariesDesktopX64Debug.d3dcompiler_47);
#else
				LoadLibraries(LibrariesDesktopX64Release.libEGL, LibrariesDesktopX64Release.libGLESv2, LibrariesDesktopX64Release.d3dcompiler_47);
#endif
#endif
#if x86
#if DEBUG
				LoadLibraries(LibrariesDesktopX86Debug.libEGL, LibrariesDesktopX86Debug.libGLESv2, LibrariesDesktopX86Debug.d3dcompiler_47);
#else
				LoadLibraries(LibrariesDesktopX86Release.libEGL, LibrariesDesktopX86Release.libGLESv2, LibrariesDesktopX86Release.d3dcompiler_47);
#endif
#endif
				void LoadLibraries(byte[] libEGL, byte[] libGLESv2, byte[] d3dcompiler_47)
				{
					var temp = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
					List<string> loadings = new List<string>();
					void DoLibrary(byte[] bs, string str)
					{
						string tempDllPath;
						tempDllPath = Path.Combine(temp, str + ".dll");
						if (File.Exists(tempDllPath))
						{
							bool write = true;
							try
							{
								File.Delete(tempDllPath);
							}
							catch
							{
								if (!File.ReadAllBytes(tempDllPath).SequenceEqual(bs))
								{
									throw;
								}
								else
								{
									write = false;
								}
							}
							if (write) File.WriteAllBytes(tempDllPath, bs);
						}
						else
						{
							File.WriteAllBytes(tempDllPath, bs);
						}
						loadings.Add(tempDllPath);
					}
					DoLibrary(libEGL, "libEGL");
					DoLibrary(libGLESv2, "libGLESv2");
					DoLibrary(d3dcompiler_47, "d3dcompiler_47");
					for (int i = 0; i < loadings.Count; i++)
					{
						LoadLibrary(loadings[i]);
					}
				}
#elif WINDOWS_UWP
				LoadPackagedLibrary(@"libEGL.dll");
				LoadPackagedLibrary(@"libGLESv2.dll");
				LoadPackagedLibrary(@"SkiaSharp.Views.Interop.UWP.dll");
#endif
				//TODO: WINDOWS_UWP
				Done = true;
			}
		}
	}
}
