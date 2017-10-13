/*
 *    Filename: <enumerator.cs>
 *
 * Description: IEnumerator usage
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
using System.Collections.Generic;

namespace CSharp.EnumerableCollections
{
    interface ILinkable<T>
    {
        T Parent { get; set; }
        T Next { get; set; }

        Int32 Value { get; set; }
    }

    class Node : ILinkable<Node>
    {
        public Node Parent { get; set; }
        public Node Next { get; set; }
        public int Value { get; set; }
    }

    class LinkedList<T> : IEnumerator<T> where T : ILinkable<T> // implementando a classe IEnumerator
    {
        private T current;

        public T Current { get { return this.current.Parent != null ? this.current.Parent : this.current; } private set { this.current = value; } }

        object IEnumerator.Current { get; }

        public void Insert(params T[] items)
        {
            foreach (var item in items)
            {
                if (this.current == null)
                    this.current = item;
                else
                {
                    item.Parent = this.current;
                    this.current.Next = item;
                    this.current = item;
                }

                Console.WriteLine("{0} inserted", item.Value);
            }

            this.Reset();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public bool MoveNext()
        {   
            this.current = this.current.Next;
            return this.current != null;
        }

        public void Reset()
        {
            while (this.Current.Parent != null)
                this.Current = this.Current.Parent;
        }
    }

    class Enumerator
    {
        public Enumerator()
        {
            Console.WriteLine("==> Enumerator");

            var month_list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var enumerator = month_list.GetEnumerator();

            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);

            foreach (var i in this.GetAll())
                Console.Write("{0} ", i);

            Console.WriteLine();
        }

        public IEnumerable<int> GetAll()
        {
            var month_list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var enumerator = month_list.GetEnumerator();

            while (enumerator.MoveNext())
                yield return enumerator.Current;

            Console.WriteLine();

            Console.WriteLine("==> Linked List");

            var linked_list = new LinkedList<Node>();
            var random = new Random();

            linked_list.Insert(
                new Node { Value = random.Next(1024) }, 
                new Node { Value = random.Next(1024) }, 
                new Node { Value = random.Next(1024) }, 
                new Node { Value = random.Next(1024) }, 
                new Node { Value = random.Next(1024) }, 
                new Node { Value = random.Next(1024) }, 
                new Node { Value = random.Next(1024) }
            );

            while (linked_list.MoveNext())
                Console.Write("{0} ", linked_list.Current.Value);
                
        }

        public static void Run()
        {
            new Enumerator();
        }
    }
}