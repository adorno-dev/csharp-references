/*
 *    Filename: <task_parallel.cs>
 *
 * Description: Task Parallelism With TPL
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example based from book Learning NET High Performance Programming
 *
 */

using System;
using System.Threading;
using System.Threading.Tasks;

using io = System.Console;

namespace CSharp.TaskParallelismTPL
{
    public class Package
    {
        public DateTime Answer { get; set; }
        public int Time { get; set; }

        public Package()
        {
            Time = new Random().Next();
            Answer = DateTime.Now;
        }

        #region +Methods

        public DateTime Latency1()
        {
            int latency = new Random().Next(10 * 1000);
            
            Thread.Sleep(latency);
            return DateTime.Now;
        }

        public DateTime Latency2()
        {
            int latency = new Random().Next(30 * 1000);
            
            Thread.Sleep(latency);
            return DateTime.Now;
        }

        #endregion
    }

    // Purpose: Parallelism with multiple instances of logic..
    class TaskParallel
    {
        /// <summary>
        /// Task in Parallel
        /// </summary>
        public TaskParallel()
        {
            #region +Case #1 

            // doExample1();
            // doExample2();
            
            #endregion

            #region +Case #2 

                doExample3();
            
            #endregion
        }

        #region +Case #1 
        
        /// <summary>
        /// Parallel.Invoke receive params of Action<>
        /// </summary>
        void doExample1()
        {
            Parallel.Invoke(doTask1, doTask2, doTask3);
            Parallel.Invoke(() => {}, () => {}, () => {});
        }

        // Practical Example 
        void doExample2()
        {
            Package package = new Package();

            // Useful to preload data
            Parallel.Invoke(
                new Action(()=>Console.WriteLine("DateTime: {0}", package.Latency1())), 
                new Action(()=>Console.WriteLine("DateTime: {0}", package.Latency2())));    // <- Slow case
            
            // Equivalent To

            Task.WaitAll(
                Task.Run(()=>Console.WriteLine("DateTime: {0}", package.Latency1())),
                Task.Run(()=>Console.WriteLine("DateTime: {0}", package.Latency2()))
            );

            Parallel.Invoke(
                new ParallelOptions { MaxDegreeOfParallelism = 2 }, // <-- Options
                doTask1, 
                doTask2, 
                doTask3);
        }

        public static void Run()
        {
            io.WriteLine("=> Task Parallel"); new TaskParallel();
            io.WriteLine();
        }

        static void doTask1() {}
        static void doTask2() {}
        static void doTask3() {}

        #endregion

        public void doExample3()
        {
            using (var cts = new CancellationTokenSource())
                using (var task1 = Task.Factory.StartNew<int>(doTask, cts.Token))
                using (var task2 = Task.Factory.StartNew<int>(doTask, cts.Token))
                using (var task3 = Task.Factory.StartNew<int>(doTask, cts.Token))
                using (var task4 = Task.Factory.StartNew<int>(doTask, cts.Token))
                {
                    var tasks = new [] {task1, task2, task3, task4};
                    var winner = Task.WaitAny(tasks);

                    cts.Cancel(); // Communicate a request for cancelation

                    io.WriteLine("The first to complete is {0} with result: {1}", winner, tasks[winner].Result);

                    try { Task.WaitAll(tasks); }
                    catch (AggregateException e) { e.Handle(ex => ex is OperationCanceledException); }
                }
        }

        private static readonly Random randomize = new Random();
        private int doTask(object token)
        {
            while (DateTime.Now < DateTime.Now.AddSeconds(randomize.Next(1, 15)))
            {
                ((CancellationToken)token).ThrowIfCancellationRequested(); Thread.Sleep(120);
            }

            return randomize.Next(1, 1000);
        }
        
    }
}