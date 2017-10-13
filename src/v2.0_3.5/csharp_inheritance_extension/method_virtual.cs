/*
 *    Filename: <method_virtual.cs>
 *
 * Description: Virtual methods (enables override)
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
    class Smartphone
    {
        public virtual void TurnOff() // Mark to be redefined with "virtual" identifier
        {
            Console.WriteLine("Smartphone: Turn Off");
        }
    }

    class Android : Smartphone
    {
        public override void TurnOff() // <-- Redefined as above
        {
            Console.WriteLine("Android: Turn Off");
        }
    }

    class Virtual
    {
        public static void Run()
        {
            Console.WriteLine("==> Virtual Method");
        }
    }
}