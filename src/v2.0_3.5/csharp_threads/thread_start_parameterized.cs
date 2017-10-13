/*
 *    Filename: <thread_parameterized.cs>
 *
 * Description: Parameterized
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

namespace CSharp.Threads
{
    class ParameterizedThreadStart // Thead delegation example
    {
        public ParameterizedThreadStart() {}

        public void Print(object limit)
        {
            for (int i = 0; i <= (int)limit; i++)
                Console.Write("{0} ", i);
        }

        public static void Run()
        {
            ParameterizedThreadStart resource = new ParameterizedThreadStart();

            // System.Threading.ParameterizedThreadStart thread_param = new System.Threading.ParameterizedThreadStart(resource.Print);
            // System.Threading.Thread thread = new System.Threading.Thread(thread_param);
            
            System.Threading.Thread thread = new System.Threading.Thread(resource.Print);
            thread.Start(10);
        }
    }
}