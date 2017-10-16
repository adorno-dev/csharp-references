using System;

using static System.Math;

namespace CSharp.Features
{
    public class ExpressionBodied
    {
        public Pointer Point { get; set; }

        public double Distance => Sqrt(Point.X * Point.X + Point.Y * Point.Y);

        public override string ToString() => $"X: {Point.X}\nY: {Point.Y}\nZ: {Point.Z}";
    }
}