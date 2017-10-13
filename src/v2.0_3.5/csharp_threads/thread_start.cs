/*
 *    Filename: <thread_start.cs>
 *
 * Description: ThreadStart
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Threading;

namespace CSharp.Threads
{
    class ThreadStart
    {
        public ThreadStart() {}

        public void Print()
        {
            for (int i = 0; i <= 10; i++)
                Console.Write("{0} ", i);
        }

        public static void Run()
        {
            ThreadStart resource = new ThreadStart();

            // Thread thread = new Thread(delegate() { resource.Print(); });
            // Thread thread = new Thread(() => resource.Print());
            // Thread thread = new Thread(resource.Print);

            Thread thread = new Thread(new System.Threading.ThreadStart(resource.Print));

            thread.Start();
        }
    }
}