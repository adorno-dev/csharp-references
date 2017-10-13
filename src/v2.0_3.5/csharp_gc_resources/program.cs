/*
 *    Filename: <program.cs>
 *
 * Description: GC (Garbage Collector)
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
    class Program
    {
        static void Main(string[] args)
        {
            Deconstructor.Run();
            Dispose.Run();
        }
    }
}
