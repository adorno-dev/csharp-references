/*
 *    Filename: <property.cs>
 *
 * Description: Property usage
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.FieldsAndProperties
{
    struct Position
    {
        private int x, y;

        public int X { get { return this.x; } set { this.x = value; } }

        public int Y { get { return this.y; } set { this.y = value; } }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Property
    {
        public Property()
        {
            Console.WriteLine("==> Property");

            Position p = new Position(10, 20);
            
            Console.WriteLine("Position: X:{0} Y:{1}", p.X, p.Y);
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Property();
        }
    }
}