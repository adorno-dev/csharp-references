/*
 *    Filename: <circle.cs>
 *
 * Description: Illustrates circle object
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ClassesAndObjects
{
    public partial class Circle
    {
        // campos
        private int radius;

        // campo compartilhado
        public static int circles = 0;

        // metodo publico
        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public static void Run()
        {
            Circle c = new Circle();
            Circle c2 = new Circle(48);
            Console.WriteLine("=> Circle");
            Console.WriteLine("Area is: {0}", c2.Area());
            Console.WriteLine("Number of circle object(s): {0}", Circle.circles);
            Console.WriteLine();
        }
    }
}