/*
 *    Filename: <property_readonly.cs>
 *
 * Description: Property Read-Only
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
    struct Position2
    {
        private int x, y;

        public int X { get { return this.x; } }

        public int Y { get { return this.y; } }

        public Position2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class PropertyReadOnly
    {
        public PropertyReadOnly()
        {
            Console.WriteLine("==> Property (Read Only)");

            Position2 p = new Position2(30, 40);

            // somente leitura
            // p.X = 10;
            // p.Y = 20; 
            
            Console.WriteLine("Position: X:{0} Y:{1}", p.X, p.Y);
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new PropertyReadOnly();
        }
    }
}