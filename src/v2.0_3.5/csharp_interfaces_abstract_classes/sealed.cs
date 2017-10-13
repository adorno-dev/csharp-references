/*
 *    Filename: <sealed.cs>
 *
 * Description: Sealed Classes (Don't allow inheritance)
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.InterfacesAndAbstractClasses
{
    sealed class Android : IOperatingSystem
    {
        public Android()
        {
            this.Version = 7F;
            this.Name = "Android";
        }

        public string Name { get; set; }
        public float Version { get; set; }

        public void Boot()
        {
            Console.WriteLine("[Android]: Booting...");
        }

        public void Shutdown()
        {
            Console.WriteLine("[Android]: Shutdown...");
        }

        public void Start()
        {
            Console.WriteLine("[Android]: Starting...");
        }
    }

    // class MyAndroid : Android {} // is a final classe (sealed) and can't be used as base class

    public class Sealed
    {
        public Sealed()
        {
            Console.WriteLine("==> Sealed");
        }

        public static void Run()
        {
            var instance = new Sealed();
        }
    }
}