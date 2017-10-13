/*
 *    Filename: <generic.cs>
 *
 * Description: Generic Example
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example extracted from book C# step by step (2008)
 */

using System;

namespace CSharp.Generics
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public T Node { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public BinaryTree(T nodeValue)
        {
            this.Node = nodeValue;
            this.Left = null;
            this.Right = null;
        }

        public void Insert(T newNode)
        {
            T current = this.Node;
            if (current.CompareTo(newNode) > 0)
                if (this.Left == null) 
                    this.Left = new BinaryTree<T>(newNode); 
                else 
                    this.Left.Insert(newNode);
            else
                if (this.Right == null)
                    this.Right = new BinaryTree<T>(newNode);
                else
                    this.Right.Insert(newNode);
        }

        public void Walk()
        {
            if (this.Left != null)
                this.Left.Walk();

            Console.WriteLine(this.Node.ToString());

            if (this.Right != null)
                this.Right.Walk();
        }
    }

    public class Generic
    {
        public Generic()
        {
            Console.WriteLine("==> Generic BinaryTree");
            
            var tree = new BinaryTree<int>(10);
            var random = new Random();

            for (int i = 0; i < 10; i++)
                tree.Insert(random.Next(100));

            tree.Walk();
        }

        public static void Run()
        {
            new Generic();
        }
    }
}