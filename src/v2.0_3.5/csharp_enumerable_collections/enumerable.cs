/*
 *    Filename: <enumerable.cs>
 *
 * Description: IEnumerable usage
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example based from book C# step by step 2008
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.EnumerableCollections
{
    class Tree<T> : IEnumerable<T> // Implementing IEnumerable
    {
        private IList<T> values = null;

        public Tree()
        {
            this.values = new List<T>();
        }

        public void Insert(params T[] items)
        {
            var values = items.GetEnumerator();
            while (values.MoveNext())
            {
                this.values.Add((T)values.Current);

                Console.WriteLine("Tree: inserted the value {0}.", (T)values.Current);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            using (var e = this.values.GetEnumerator())
                while (e.MoveNext())
                    yield return e.Current;
        }

        IEnumerator IEnumerable.GetEnumerator() { return this.values.GetEnumerator(); }
    }

    class Enumerable
    {
        public Enumerable()
        {
            Console.WriteLine("==> Enumerable");

            var month_list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var enumerable = month_list as IEnumerable<int>; // IEnumerable uses IEnumerator internally

            foreach (var month in month_list)
                Console.WriteLine(month);

            Console.WriteLine();
            Console.WriteLine("==> IEnumerable Class");

            Tree<int> tree = new Tree<int>();
            tree.Insert(1, 3, 5, 7, 9, 11, 13, 15);

            IEnumerator<int> values = tree.GetEnumerator();

            while(values.MoveNext())
                Console.WriteLine("Tree: reading the value {0}.", values.Current);

            Console.WriteLine();
        }

        public static void Run()
        {
            new Enumerable();
        }
    }
}