/*
 *    Filename: <queue.cs>
 *
 * Description: How to work with Collections => Queue
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
    public class Queue
    {
        // FIFO (First In, First Out)
        public Queue()
        {
            Console.WriteLine("=> Queue");

            System.Collections.Queue numbers = new System.Collections.Queue();

            foreach (int number in new int[] {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21})
            {
                numbers.Enqueue(number);
                Console.WriteLine("Number: {0} has joined the queue.", number); // entra na fila
            }

            Console.Write("Iterator: ");
            foreach (int number in numbers)
                Console.Write("{0} ", number);

            Console.WriteLine();

            while (numbers.Count > 0)
            {
                int value = (int) numbers.Dequeue();
                Console.WriteLine("Number: {0} has left the queue.", value);
            }

            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Queue();
        }
    }
}