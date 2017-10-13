/*
 *    Filename: <method_override.cs>
 *
 * Description: Overriding virtual methods
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
    class Celular : Android
    {
        public override void TurnOff() 
        {
            Console.WriteLine("Celular: Turn Off");
        }
    }

    class App : Celular
    {
        public override void TurnOff()
        {
            base.TurnOff();
        }
    }

    public class Override
    {
        public Override()
        {
            Console.WriteLine("==> Override");
        }

        public static void Run()
        {
            var instance = new App();
            instance.TurnOff();
        }
    }
}