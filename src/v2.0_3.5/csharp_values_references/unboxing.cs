/*
 *    Filename: <unboxing.cs>
 *
 * Description: Unboxing Objects
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

using CSharp.ClassesAndObjects;

namespace CSharp.ValuesAndReferences
{
    public class Unboxing
    {
        public static void Run()
        {
            Console.WriteLine("=> Unboxing");

            Circle c = new Circle();
            
            int i = 42;
            object o;

            o = c;          // Refer a Circle
            // i = o;       // Store in i variable?
            // i = (int)o;  // Can't compile, throw exception!

            o = i;          // Boxing
            i = (int)o;     // Can compile it, but throw exception!

            // Safe casting with "is" operator
            
            object another = c;

            if (another is Circle)
            {
                Circle c2 = (Circle)another; // <-- Safe
            }


            // Safe casting with "as" operator.. returns null on fail.
            Circle c3 = c as Circle;

            if (c3 == null)
                throw new NullReferenceException("Unboxing error!!!");
            else
                Console.WriteLine("[Message]: Unboxing with successfully!");

            Console.WriteLine();
        }
    }
}