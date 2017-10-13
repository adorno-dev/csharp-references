/*
 *    Filename: <hashtable.cs>
 *
 * Description: How to work with Collections => Hashtable
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ArraysAndCollections
{
    public class Hashtable
    {
        public Hashtable()
        {
            Console.WriteLine("=> Hashtable");

            System.Collections.Hashtable ages = new System.Collections.Hashtable();

            ages["Peter"] = 42;
            ages["John"] = 43;
            ages["Paul"] = 47;
            ages["Mathew"] = 37;

            System.Collections.Hashtable ages2 = new System.Collections.Hashtable()
            {
                { "Peter", 42 },
                { "John", 43 },
                { "Paul", 47 },
                { "Mathew", 37 }
            };

            foreach (System.Collections.DictionaryEntry e in ages2)
                Console.WriteLine("Name: {0}, Age: {1}", (string)e.Key, (int)e.Value);
            
            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Hashtable();
        }
    }
}