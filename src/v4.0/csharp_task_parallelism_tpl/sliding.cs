/*
 *    Filename: <sliding.cs>
 *
 * Description: Sliding Parallel Programming
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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using io = System.Console;

namespace CSharp.Parallel_Sliding
{
    public class Sliding
    {
        public Sliding() 
        {
            IEnumerable<int> data = this.GetData();

            Parallel.ForEach(data, new ParallelOptions { MaxDegreeOfParallelism = 2 }, i => { io.WriteLine("Processing {0}...", i); Thread.Sleep(2000); });

            io.WriteLine("Completed!");
        }

        public IEnumerable<int> GetData()
        {
           int i = 0;
           while (i++ < 10)
           {
               io.WriteLine("Yielding {0}...", i);
               yield return i;
           }
        }

        // This scenario gives tremendous computational power without having to keep in
        // memory all data altogether, thus, only actually processing objects resides in memory.
        public static void Run()
        {
            io.WriteLine("=> Parallel Partitions"); new Sliding();
            io.WriteLine();
        }
    }
}