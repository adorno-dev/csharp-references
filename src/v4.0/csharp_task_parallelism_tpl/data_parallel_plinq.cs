/*
 *    Filename: <data_parallel_plinq.cs>
 *
 * Description: Data parallelism with PLINQ
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using io = System.Console;

namespace CSharp.Parallel_Partitions
{
    public class PartitionsPLINQ
    {
        public PartitionsPLINQ() 
        {
            // this.MainTask();
            // this.MainTaskOptimized();
            this.MainTaskCustomized();
        }

        public void MainTask()
        {
            IEnumerable<int> data = Enumerable.Range(1, 1024);

            // multi-level in-memory where executed as data parallelism
            var parallel_processed = data.AsParallel()
                                         .Where(w => this.CheckIfAllowed1(w))
                                         .Where(w => this.CheckIfAllowed2(w))
                                         .ToArray();
        }

        public void MainTaskOptimized()
        {
            var data = Enumerable.Range(1, 1024).ToArray();
            var partitioner = Partitioner.Create<int>(data, false); // <-- See more about the Partitioner class..

            partitioner.AsParallel()
                       .ForAll(item =>
                       {
                           Console.WriteLine("Item {0} Task {1} Thread {2}", item, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                           Thread.Sleep(2000);
                       });

        }

        public void MainTaskCustomized()
        {
            var data = Enumerable.Range(1, 1024).ToArray();
            var partitioner = new CustomChunkPartitioner(data);

            partitioner.AsParallel().ForAll(item =>
            {
                Console.WriteLine("Item {0} Task {1} Thread {2}", item, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
            });
        }

        private bool CheckIfAllowed2(int x)
        {
            io.WriteLine("Step 2 -> Checking {0}", x); Thread.Sleep(1000);
            return x % 3 == 0;
        }

        private bool CheckIfAllowed1(int x)
        {
            io.WriteLine("Step 1 -> Checking {0}", x); Thread.Sleep(1000);
            return x % 2 == 0;
        }

        public static void Run()
        {
            io.WriteLine("=> Parallel Partitions"); new PartitionsPLINQ();
            io.WriteLine();
        }
    }

    // only use for testing purpose
    public class CustomChunkPartitioner : Partitioner<int>
    {
        public IEnumerable<int> Items { get; private set; }
        public CustomChunkPartitioner(IEnumerable<int> items) { this.Items = items; }

        public override IList<IEnumerator<int>> GetPartitions(int partition_count)
        {
            var result = new List<IEnumerator<int>>();
            var page_size = this.Items.Count(); // partition counter

            for (int page = 0; page < partition_count; page++)
                result.Add(this.Items.Skip(page * page_size).Take(page_size).GetEnumerator());
            
            return result;
        }

    }
}