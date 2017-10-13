/*
 *    Filename: <bits.cs>
 *
 * Description: Manipulating bits via index
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example extracted from book C# step by step (2008)
 *
 */

using System;

namespace CSharp.Indexers
{
    class Bit
    {
        public Bit() // Defining a class to do it!
        {
            sbyte bit = 64;          

            bit &= ~(1 << 6); // Assign &= 6th bit to 0 ( ~ = not )

            bit |= 1 << 6; // Assign 6th bit to 1

            if ((bit & (1 << 6)) != 0)
                Console.WriteLine("6º bit is 1. 0b100000 (64)");
            else
                Console.WriteLine("6º bit is 0. 0b000000 (0)");

            unchecked
            {
                var variable = (sbyte)0b11001100;

                Console.WriteLine("variable: {0}", (byte) ~variable);           // 0b00110011 51 decimal (not)
                Console.WriteLine("variable: {0}", (byte) (variable << 2));     // 0b00110000 48 decimal (offset 2)
                Console.WriteLine("variable: {0}", (byte) (variable | 24));     // 0b11011100 220 decimal (or)
                Console.WriteLine("variable: {0}", (byte) (variable & 24));     // 0b00001000 8 decimal (and)
                Console.WriteLine("variable: {0}", (byte) (variable ^ 24));     // 0b00001000 212 decimal (xor)
            }
        }

        public static void Run()
        {
            var instance = new Bit();
        }
    }
}
