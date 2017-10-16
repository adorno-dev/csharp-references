using System;

using static System.Math;

namespace CSharp.Features
{
    public class UsingStaticMembers
    {
        public Pointer Point { get; set; }

        public double Distance { get; private set; }

        public UsingStaticMembers()
        {
            this.Distance = Sqrt(Point.X * Point.X + Point.Y * Point.Y); // <- Sqrt called directly from static member
        }
    }
}