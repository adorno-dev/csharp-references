/*
 *    Filename: <program.cs>
 *
 * Description: Values, References, Boxing And Unboxing
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
    class Program
    {
        static void Main(string[] args)
        {
            Value.Run();
            Reference.Run();
            Param.Run();
            Boxing.Run();
            Unboxing.Run();
        }
    }
}
