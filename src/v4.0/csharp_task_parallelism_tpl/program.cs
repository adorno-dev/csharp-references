/*
 *    Filename: <program.cs>
 *
 * Description: Parallelism
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using CSharp.DataParallelismTPL;
using CSharp.Parallel_Abortion;
using CSharp.Parallel_Partitions;
using CSharp.Parallel_Sliding;

namespace CSharp.TaskParallelismTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            // TaskParallel.Run();
            // DataParallel.Run();
            // Abortion.Run();
            // Partitions.Run();
            // Sliding.Run();
            // PartitionsPLINQ.Run();
            PartitionsPLINQ.Run();
        }
    }
}
