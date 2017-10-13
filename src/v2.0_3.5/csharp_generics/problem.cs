/*
 *    Filename: <problem.cs>
 *
 * Description: Boxing, Unboxing
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections;

namespace CSharp.Generics
{
    class Problem
    {
        public Problem()
        {
            // Boxing and unboxins cost performance
            // We resolve this issue with generics (see solution.cs)

            Queue q = new Queue();
            Int32 i = 77;

            q.Enqueue(i);               // <- Boxing from i to object
            i = (Int32) q.Dequeue();    // <- Unboxing from object to i
        }

        public static void Run()
        {
            new Problem();
        }
    }
}