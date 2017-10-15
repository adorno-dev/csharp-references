/*
 *    Filename: <aborting.cs>
 *
 * Description: Aborting Parallel Tasks
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

namespace CSharp.Parallel_Abortion
{
    public class Abortion
    {
        public Abortion()
        {
            var range = Enumerable.Range(1, 1024);
            var counter = 0;

            Parallel.ForEach(range, (key, state) =>
            {
                try // verifying if something gone wrong!
                {
                    doTask(key);

                    io.WriteLine((state.IsStopped) ? 
                        string.Format("Executed # {0} when IsStopped was true", counter++) : 
                        string.Format("Executed # {0}", counter++));
                }
                catch (Exception e)
                {
                    state.Stop(); // <-- This method request the abortion of Parallel. Breaks doesn't work!
                    io.WriteLine("Error: {0}", e.Message); 
                    io.WriteLine("Requested a parallel state break!");
                }
            });

            io.WriteLine("Tasks Completed!");
        }

        private readonly Random gen = new Random();
        private void doTask(int key)
        {
            Thread.Sleep(gen.Next(1000, 2000));
            
            if (DateTime.Now.Millisecond >= 700)
                throw new Exception("Something gone wrong!!!");
        }

        public static void Run()
        {
            io.WriteLine("=> Parallel Abortion"); new Abortion();
            io.WriteLine();
        }
    }
}