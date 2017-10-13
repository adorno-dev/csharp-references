/*
 *    Filename: <values.cs>
 *
 * Description: Value-Type
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
    public class Value
    {
        public void Copy()
        {
            int x = 42; // Declare and initilize
            int cx = x; // Copy of x
            x++;        // Increment x without affect cx
        }

        public void Pass()
        {
            int local_variable = 0;

            void TryChange(int v)
            {
                v = 42;
            }

            Console.WriteLine("=> Pass Value");
            Console.WriteLine("local_variable = {0}", local_variable);
            TryChange(local_variable);
            Console.WriteLine("local_variable = {0}", local_variable);
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Value();
            instance.Copy();
            instance.Pass();
        }
    }
}