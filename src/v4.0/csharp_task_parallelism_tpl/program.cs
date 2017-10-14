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

namespace CSharp.TaskParallelismTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskParallel.Run();
            DataParallel.Run();
        }
    }
}
