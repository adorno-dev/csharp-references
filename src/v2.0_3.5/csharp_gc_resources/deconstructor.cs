/*
 *    Filename: <deconstructor.cs>
 *
 * Description: Deconstuctors
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.GarbageCollector
{
    class Simple
    {
        private static int instances = 0;

        public Simple()
        {
            instances++;
        }

        // Avoid deconstructors, give GC works for you..
        // We recommend the using with IDisposible objects
        ~Simple()
        {
            instances--;
        }
    }

    public class Deconstructor
    {
        public Deconstructor()
        {
            Console.WriteLine("==> Deconstructor");

            Simple s1 = new Simple();
            Simple s2 = new Simple();
            Simple s3 = new Simple();
            Simple s4 = new Simple();
        }

        public static void Run()
        {
            var instance = new Deconstructor();
        }
    }
}