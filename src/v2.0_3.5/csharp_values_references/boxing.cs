/*
 *    Filename: <boxing.cs>
 *
 * Description: Values, References, Boxing And Unboxing
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

using CSharp.ClassesAndObjects;

namespace CSharp.ValuesAndReferences
{
    public class Boxing
    {
        public static void Run()
        {
            Console.WriteLine("=> Boxing");

            // Reference type
            Circle c;
            c = new Circle(42);

            // System.Object variable
            object o;
            o = c;

            // Can refer value-type too
            int i = 42;
            o = i;

            // If change both i than your value.. don't affect (value-type)

            Console.WriteLine();
        }
    }
}