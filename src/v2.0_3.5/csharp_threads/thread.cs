/*
 *    Filename: <threads.cs>
 *
 * Description: Threads Execution
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
    class Work
    {
        private static int worker_count = 0;

        public Work() {}

        private void Latency()
        {
            Thread.Sleep(5000);
        }

        public void Toggle()
        {
            int thread_id = ++worker_count;

            Console.WriteLine("Toggle On Started! ({0})", thread_id);
            
            Latency();
            
            Console.WriteLine("Toggle On Stopped! ({0})", thread_id);
        }

        public static void Run()
        {
            Work workaround = new Work();                       
            
            Thread worker_thread1 = new Thread(workaround.Toggle);
            Thread worker_thread2 = new Thread(workaround.Toggle);
            Thread worker_thread3 = new Thread(workaround.Toggle);
            
            worker_thread1.Start();
            worker_thread2.Start();
            worker_thread3.Start();
        }
    }
}