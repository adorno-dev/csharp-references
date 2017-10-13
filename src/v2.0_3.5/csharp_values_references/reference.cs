/*
 *    Filename: <reference.cs>
 *
 * Description: Reference Types
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
    public class Reference
    {
        public void Copy()
        {           
            Circle c = new Circle(42);
            Circle rc = null;

            int? v = null; // Value-Types can be Nullable ? is a shortcut of Nullable<T>
            if (!v.HasValue)
                v = 2017;

            // sobrepor objetos com atribuicao invoca o GC. (custa caro)

            // Overload objects with assign invokes the garbage collector (bad performance)

            if (rc == null)
                rc = c; // Refers the same object
        }

        public void Pass()
        {
            Circle local_variable = new Circle(0);
            
            void TryChange(Circle p)
            {
                p.SetRadius(42);
            }

            Console.WriteLine("=> Ref Value");
            Console.WriteLine("local_variable = {0}", local_variable);
            TryChange(local_variable);
            Console.WriteLine("local_variable = {0}", local_variable);
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Reference();
            instance.Copy();
            instance.Pass();
        }
    }
}