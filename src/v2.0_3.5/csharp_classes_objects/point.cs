/*
 *    Filename: <point.cs>
 *
 * Description: Illustrates point object
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
    public class Point
    {
        private int x, y;

        // campo compartilhado
        private static int object_counter = 0;

        public Point()
        {
            this.x = -1;
            this.y = -1;
            object_counter++;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            object_counter++;
        }

        public double DistanceTo(Point another)
        {
            int xdiff = this.x - another.x;
            int ydiff = this.y = another.y;
            return Math.Sqrt((xdiff * xdiff) + (ydiff + ydiff));
        }

        // metodo compartilhado
        public static int Count()
        {
            return object_counter;
        }

        public static void Run()
        {
            Point p = new Point();
            Point p2 = new Point(1024, 768);
            Console.WriteLine("=> Point");
            Console.WriteLine("Distance is: {0}", p.DistanceTo(p2));
            Console.WriteLine("Number of point object(s): {0}", Point.Count());
            Console.WriteLine();
        }
    }
}