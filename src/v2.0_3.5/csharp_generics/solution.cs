/*
 *    Filename: <solution.cs>
 *
 * Description: Generic Queue
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections.Generic;

namespace CSharp.Generics
{
    class Solution
    {
        public Solution()
        {
            Queue<int> q = new Queue<int>();
            Int32 i = 77;

            // boxing int como argumento
            q.Enqueue(i);

            // retorna o inteiro diretamente
            i = q.Dequeue();
        }

        public static void Run()
        {
            new Problem();
        }
    }
}