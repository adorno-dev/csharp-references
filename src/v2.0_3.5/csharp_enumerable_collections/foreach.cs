/*
 *    Filename: <foreach.cs>
 *
 * Description: Foreach usage
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.EnumerableCollections
{
    class Foreach
    {
        public Foreach() 
        {
            Console.WriteLine("==> Foreach");

            int[] enumerable = { 1, 3, 5, 7, 9 };

            // foreach funciona somente com objetos que implementam IEnumerable (colecoes enumeraveis)
            foreach (int number in enumerable)
                Console.WriteLine(number);
        }

        public static void Run()
        {
            new Foreach();
        }
    }
}