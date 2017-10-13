/*
 *    Filename: <program.cs>
 *
 * Description: Threads
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Work.Run();
            ThreadStart.Run();
            ParameterizedThreadStart.Run();
            ThreadCallback.Run();
            Join.Run();
            Concurrent.Run();
            Lock.Run();
            DeadLock.Run();

            Console.WriteLine("Processor Count: {0}", Environment.ProcessorCount);
        }
    }
}
