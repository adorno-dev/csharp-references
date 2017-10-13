/*
 *    Filename: <thread_join.cs>
 *
 * Description: Join
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace CSharp.Threads
{
    class Join
    {
        public Join()
        {
            Console.WriteLine("Main Thread Started.");

            System.Threading.Thread thread1 = new System.Threading.Thread(Thread_Callback1);
            System.Threading.Thread thread2 = new System.Threading.Thread(Thread_Callback2);

            thread1.Start();
            thread2.Start();

            // esperando thread1
            if (thread1.Join(1000))
                Console.WriteLine("=> Thread_Callback1 Completed.");
            else
                Console.WriteLine("=> Thread_Callback1 Has Not Completed Yet!");

            // esperando thread2
            thread2.Join(); Console.WriteLine("=> Thread_Callback2 Completed.");

            if (thread1.IsAlive)
            {
                Console.WriteLine("=> Thread_Callback1 Is Still Doing It's Work...");

                while (thread1.IsAlive) System.Threading.Thread.Sleep(500);

                Console.WriteLine("=> Thread_Callback1 Completed.");
            }

            Console.WriteLine("Main Thread Completed.");
        }

        public void Thread_Callback1()
        {
            Console.WriteLine("=> Thread_Callback1 Started.");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("=> Thread_Callback1 Is About To Return.");
        }

        public void Thread_Callback2()
        {
            Console.WriteLine("=> Thread_Callback2 Started.");
        }

        public static void Run()
        {
            new Join();
        }
    }
}