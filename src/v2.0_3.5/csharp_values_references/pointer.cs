/*
 *    Filename: <pointer.cs>
 *
 * Description: Pointers like C
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ValuesAndReferences
{
    public class Pointer
    {
        // Pointers like C is possible when using unsafe modifier

        public Pointer()
        {
            // int *ptr_i;
            // int i = 77;
            // ptr_i = &i;

            // *ptr_i = 100;
        }

        // public static unsafe void Run()
        // {
        //     Console.WriteLine("=> Pointers ");

        //     int x = 77, y = 88;
        //     unsafe
        //     {
        //         Swap(&x, &y);
        //     }

        //     Console.WriteLine();
        // }

        // public static unsafe void Swap(int *x, int *y)
        // {
        //     int tmp;
        //     tmp = *x;
        //     *x = *y;
        //     *y = tmp;
        // }
    }
}