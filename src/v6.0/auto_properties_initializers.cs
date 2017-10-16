using System;

namespace CSharp.Features
{
    public class Pointer
    {
        public Pointer()
        {
        }

        public Pointer(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int X { get; } = 10;
        public int Y { get; } = 20;
        public int Z { get; private set; } = 30;
    }
}