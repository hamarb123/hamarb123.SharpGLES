SharpGLES
=========

OpenGL ES 2.0 for .NET Framework (Windows Forms) and the Universal Windows Platform (.NET)

The are examples in the Examples folder.

Based off of the code https://github.com/bitlush/SharpGLES

View examples in Examples folder

This project uses binaries from Google's angle project (https://code.google.com/p/angleproject/) under the New BSD license which can be read here:
https://chromium.googlesource.com/angle/angle/+/master/LICENSE

This project uses binaries from Microsoft's SkiaSharp project (https://github.com/mono/SkiaSharp) under the MIT license which can be read here:
https://github.com/mono/SkiaSharp/blob/master/LICENSE.md

Minimum versions project:
* UWP: 10.0.10586
* DESKTOP: .NET 4.6.1

STEPS:
1. Copy binaries from the built Binaries folder / releases page
2. If you are not using the Universal Windows Platform then skip to step 4
3. Add reference to ANGLE.WindowsStore and SkiaSharp.Views.Interop.UWP
4. Add your own code