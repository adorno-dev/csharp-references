/*
 *    Filename: <array_list.cs>
 *
 * Description: How to work with ArrayList
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
    public class ArrayList
    {
        public ArrayList()
        {
            Console.WriteLine("=> ArrayList");

            System.Collections.ArrayList numbers = new System.Collections.ArrayList();

            foreach (int value in new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})
                numbers.Add(value);

            System.Collections.ArrayList numbers2 = new System.Collections.ArrayList()
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            
            numbers.Insert(numbers.Count - 1, 77);

            // Removing by value
            numbers.Remove(6);

            // Remove by index
            numbers.RemoveAt(2);

            Console.Write("For: ");

            for (int i = 0; i < numbers.Count; i++)
                Console.Write(string.Format("{0}:{1} ", i, numbers[i]));

            Console.WriteLine();

            Console.Write("Foreach: ");

            foreach (int number in numbers)
                Console.Write(string.Format("{0} ", number));

            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new ArrayList();
        }
    }
}