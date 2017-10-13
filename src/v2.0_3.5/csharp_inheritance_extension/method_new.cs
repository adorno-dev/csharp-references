/*
 *    Filename: <method_new.cs>
 *
 * Description: Hides methods from base class with new operator
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.InheritanceExtension
{
    class Computer
    {
        public void TurnOff() {} // Turn off the computer
    }

    class OS : Computer
    {
        // Operator new hides TurnOff method of Computer 
        public new void TurnOff() {} // Runs TurnOff via OS
    }

    class New
    {
        public static void Run()
        {
            Console.WriteLine("==> New Method");
        }
    }
}