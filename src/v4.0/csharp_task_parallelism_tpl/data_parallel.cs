/*
 *    Filename: <data_parallel.cs>
 *
 * Description: Fata Parallelism With TPL
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
using System.Threading.Tasks;
using io = System.Console;

namespace CSharp.DataParallelismTPL
{

    class DataParallel
    {
        // Purpose: One kind of logic to bunch of data
        public DataParallel() {}

        public void ExampleMethod1()
        {
            for (int i = 0; i < 10; i++) { /* block code */ }

            Parallel.For(0, 10, i => { /* block code */ });
        }

        public void ExampleMethod2()
        {
            IEnumerable<int> invoice = new [] { 1, 2, 3, 4, 5 };
            ParallelOptions parallel_options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
            Parallel.ForEach(invoice, key => { /* block code */ });
            Parallel.ForEach(invoice, parallel_options, key => { /* block code */ });
        }

        public static void Run()
        {
            io.WriteLine("=> Data Parallel"); new DataParallel();
            io.WriteLine();
        }
    }

}