/*
 *    Filename: <thread_concurrent.cs>
 *
 * Description: Concurrent
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
using System.Diagnostics;

namespace CSharp.Threads
{
    class Concurrency
    {
        private static int subscribers = 0;
        private static object _lock = new object();

        public Concurrency()
        {
            Console.WriteLine("=> Thread Concurrent");

            // this.Simulate();
            // this.Simulate();
            // this.Simulate();
            
            Stopwatch watcher = Stopwatch.StartNew();
            Thread thread1 = new Thread(Simulate);
            Thread thread2 = new Thread(Simulate);
            Thread thread3 = new Thread(Simulate);

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

        public void Simulate()
        {
            // for (int s = 1; s <= 7000000; s++) subscribers++; // operator++ is'nt thread safe
            // for (int s = 1; s <= 7000000; s++) Interlocked.Increment(ref subscribers);
            for (int s = 1; s <= 7000000; s++) lock(_lock) { subscribers++; };
        }

        public static void Run()
        {
            new Concurrency();
        }
    }
}