/*
 *    Filename: <thread_syncronized.cs>
 *
 * Description: Syncronization Threads
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Diagnostics;
using System.Threading;

namespace CSharp.Threads
{
    // Monitor object and lock() offers the same mechanism to sync the object access. (lock() is a simple method of Monitor)
    class Lock
    {
        private static object _lock = new object();
        private static int subscribers = 0;

        public Lock()
        {
            Console.WriteLine("==> Lock");

            Stopwatch watcher = Stopwatch.StartNew();
            Thread thread1 = new Thread(Subscribe);
            Thread thread2 = new Thread(Subscribe);
            Thread thread3 = new Thread(Subscribe);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            watcher.Stop();

            Console.WriteLine("==> Total Subscribers: {0} in [{1}]", subscribers, watcher.ElapsedTicks);
            Console.WriteLine();

        }

        public void Subscribe()
        {
            for (int i = 1; i < 7000000; i++)
                lock(_lock) subscribers++;
        }

        public static void Run()
        {
            new Lock();
        }
    }

    class Monitor
    {
        // private static object _lock = new object();
        // private static int subscribers = 0;

        public void Subscribe()
        {
            // for (int i = 1; i < 7000000; i++)
            // {
            //     Monitor.Enter(_lock);
            //     try { subscribers++; }
            //     finally 
            //     {
            //         Monitor.Exit(_lock);
            //     }
            // }

            Console.WriteLine(".NET Core 2.0 Does not support Monitor.Enter and Monitor.Exit");
        }
    }
}