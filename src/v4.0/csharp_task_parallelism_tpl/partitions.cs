/*
 *    Filename: <partitions.cs>
 *
 * Description: Partioning piece of data
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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using io = System.Console;

namespace CSharp.Parallel_Partitions
{
    public class Partitions
    {
        public Partitions() 
        {
            this.RangePartition();
        }

        public void RangePartition()
        {
            Parallel.For(1, 1024, item =>
            {
                io.WriteLine("Item: {0} Task: {1} Thread: {2}", item, 
                    Task.CurrentId, 
                    Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(2000);
            });
        }

        public static void Run()
        {
            io.WriteLine("=> Parallel Partitions"); new Partitions();
            io.WriteLine();
        }
    }
}