/*
 *    Filename: <stack.cs>
 *
 * Description: How to work with Collections => Stack
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
    public class Stack
    {
        // LIFO (Last In, First Out)
        public Stack()
        {
            Console.WriteLine("=> Stack");

            System.Collections.Stack numbers = new System.Collections.Stack();

            foreach (int number in new int[] {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21})
            {
                numbers.Push(number);
                Console.WriteLine("Number: {0} has been pushed on the stack.", number); // entra na pilha
            }

             Console.Write("Iterator: ");

            foreach (int number in numbers)
                Console.Write("{0} ", number);

            // Peek method reads without remove it

            // for (int i = 0; i < numbers.Count; i++)
            //     Console.Write("{0}:{1} ", i, (int)numbers.Peek());
            
            Console.WriteLine();

            while (numbers.Count > 0)
            {
                int number = (int) numbers.Pop();
                Console.WriteLine("Number: {0} has been popped of the stack.", number); // saiu da pilha
            }

            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Stack();
        }
    }
}