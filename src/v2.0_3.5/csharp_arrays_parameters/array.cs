/*
 *    Filename: <arrays.cs>
 *
 * Description: How to work with arrays
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ArrayAndParameters
{
    public class Array
    {
        public Array()
        {
            int[] two = { 1, 3 };
            int[] three = { -1, -3, 5, 7 };
            int min_by2 = this.Min(two);
            int min_by3 = this.Min(three);

            Console.WriteLine("=> Array (Go Hourse Mode)");
            Console.WriteLine("Two: Min = {0}", min_by2);
            Console.WriteLine("Three: Min -> {0}", min_by3);
            Console.WriteLine();
        }

        public int Min(int[] param_list) // <-- simple array
        {
            int? current = null;

            if (param_list == null || param_list.Length == 0)
                throw new ArgumentException("Not enough arguments.");
            else
                current = param_list[0];

            foreach (int value in param_list)
                if (value < current)
                    current = value;
            
            return current.Value;
        }

        public static void Run()
        {
            var instance = new Array();
        }
    }
}