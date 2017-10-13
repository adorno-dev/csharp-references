/*
 *    Filename: <generic_method.cs>
 *
 * Description: Generic Methods
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example extracted from book C# step by step (2008)
 */

using System;

namespace CSharp.Generics
{
    class GenericMethod
    {
        public GenericMethod()
        {
            Console.WriteLine("==> Generic Method");

            string a = "GNU", b = "Adorno";
            int x = 71, z = 72;

            Console.WriteLine("Before => a:{0} and b:{1}", a, b);
            Console.WriteLine("Before => x:{0} and z:{1}", x, z);

            this.Swap(ref x, ref z);
            this.Swap(ref a, ref b);

            Console.WriteLine("After => a:{0} and b:{1}", a, b);
            Console.WriteLine("After => x:{0} and z:{1}", x, z);
        }

        public void Swap<T>(ref T left, ref T right)
        {
            T between = left;
            left = right;
            right = between;
        }

        public static void Run()
        {
            new GenericMethod();
        }
    }
}