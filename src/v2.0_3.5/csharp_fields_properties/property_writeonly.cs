/*
 *    Filename: <property_writeonly.cs>
 *
 * Description: Property Write-Only
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
    struct Position3
    {
        private int x, y;

        public int X { set { this.x = value; } }

        public int Y { set { this.y = value; } }

        public Position3(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class PropertyWriteOnly
    {
        public PropertyWriteOnly()
        {
            Console.WriteLine("==> Property (Write Only)");

            Position3 p = new Position3(50, 60);

            // somente escrita
            // int x = p.X;
            // int y = p.Y;

            Console.Write("X: "); p.X = int.Parse(Console.ReadLine());
            Console.Write("Y: "); p.Y = int.Parse(Console.ReadLine());
            
            // Console.WriteLine("Position: X:{0} Y:{1}", p.X, p.Y);
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new PropertyWriteOnly();
        }
    }
}