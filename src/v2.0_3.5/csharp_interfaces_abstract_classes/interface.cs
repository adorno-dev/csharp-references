/*
 *    Filename: <interface.cs>
 *
 * Description: Interface with inheritance
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
    interface IComputer
    {
        IOperatingSystem OperatingSystem { get; set; }
        float MemorySize { get; set; }
        float HardDiskSize { get; set; }
        
        string TurnOn();
        string TurnOff();
        string Reset();
    }

    interface IOperatingSystem
    {
        string Name { get; set; }
        float Version { get; set; }
        
        void Boot();
        void Shutdown();
        void Start();
    }

    class Computer : IComputer
    {
        public Computer() { }

        public IOperatingSystem OperatingSystem { get; set; }
        public float MemorySize { get; set; }
        public float HardDiskSize { get; set; }

        public string Reset()
        {
            return "Computer says: Reset";
        }

        public string TurnOff()
        {
            return "Computer says: Turn Off";
        }

        public string TurnOn()
        {
            return "Computer says: Turn On";
        }
    }

    class MacOS : IComputer, IOperatingSystem
    {
        public MacOS() 
        {
            this.MemorySize = 8F;
            this.HardDiskSize = 250F;
            this.Boot();
            this.Start();
            this.Shutdown();
            this.TurnOff();
        }

        public IOperatingSystem OperatingSystem { get; set; }
        public float MemorySize { get; set; }
        public float HardDiskSize { get; set; }
        public string Name { get; set; }
        public float Version { get; set; }
        
        public void Boot()
        {
            Console.WriteLine("[MacOS]: Booting...");
        }

        public string Reset()
        {
            return "[MacOS]: Reset";
        }

        public void Shutdown()
        {
            Console.WriteLine("[MacOS]: Shutdown...");
        }

        public void Start()
        {
            Console.WriteLine("[MacOS]: Start X Management...");
        }

        public string TurnOff()
        {
            return "[MacOS]: Turn Off";
        }

        public string TurnOn()
        {
            return "[MacOS]: Turn On";
        }
    }

    public class Interface
    {
        public Interface()
        {
            Console.WriteLine("==> Interface");
            MacOS operating_system = new MacOS();
        }

        public static void Run()
        {
            var instance = new Interface();
        }
    }
}