/*
 *    Filename: <param.cs>
 *
 * Description: Working with parameters
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ValuesAndReferences
{
    public class Param
    {
        static void Ref(ref int param)
        {
            param++;
        }

        static void Out(out int param)
        {
            param = 42;
        }

        public static void Run()
        {
            int v = 42;

            Console.WriteLine("=> Parameter => Run (REF)");
            Console.WriteLine("[Before]: Value: {0}", v);
            Ref(ref v);
            Console.WriteLine("[After]: Value: {0}", v);
            Console.WriteLine();

            v = 0;

            Console.WriteLine("=> Parameter => Run (OUT)");
            Console.WriteLine("[Before]: Value: {0}", v);
            Out(out v);
            Console.WriteLine("[After]: Value: {0}", v);
            Console.WriteLine();
        }
    }
}