using System;

using io = System.Console;

namespace CSharp.Features
{
    public class StringInterpolation
    {
        public StringInterpolation()
        {
            var p = new Pointer();
            
            io.WriteLine($"X: {p.X} - Y: {p.Y} - Z: {p.Z}");
        }
    }
}