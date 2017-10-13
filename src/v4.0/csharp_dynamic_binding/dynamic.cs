/*
 *    Filename: <dynamic.cs>
 *
 * Description: Dynamic Binding (Like Python)
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

using io = System.Console;

namespace CSharp.DynamicBinding
{
    class Dynamic
    {
        public Dynamic()
        {
            // Supports any type at compile time (Like Python)
            
            dynamic variable = null; 

            variable = 10;
            io.WriteLine("variable: type: {0} - value: {1}", variable.GetType(), variable);
            
            variable = "Ten";
            io.WriteLine("variable: type: {0} - value: {1}", variable.GetType(), variable);

            variable = false;
            io.WriteLine("variable: type: {0} - value: {1}", variable.GetType(), variable);

            variable = variable.GetType();
            io.WriteLine("variable: type: {0} - value: {1}", variable.GetType(), variable);

            io.WriteLine();
        }

        public static void Run()
        {
            io.WriteLine("=> Dynamic Binding"); new Dynamic();
        }
    }
}