/*
 *    Filename: <abstract.cs>
 *
 * Description: Abstract class (Use inheritance and can't be instantiated)
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
    abstract class Workstation : IComputer
    {
        public Workstation(IOperatingSystem OperatingSystem) 
        {
            this.OperatingSystem = OperatingSystem;
        }

        public IOperatingSystem OperatingSystem { get; set; }
        public float MemorySize { get; set; }
        public float HardDiskSize { get; set; }

        public string Reset()
        {
            return "[Workstation]: Reset";
        }
        public string TurnOff()
        {
            return "[Workstation]: Turn Off";
        }
        public string TurnOn()
        {
            return "[Workstation]: Turn On";
        }
    }

    class Windows : IOperatingSystem
    {
        public Windows()
        {
            this.Name = "Windows";
            this.Version = 10;
        }

        public string Name { get; set; }
        public float Version { get; set; }

        public void Boot()
        {
            Console.WriteLine("[Windows]: Booting...");
        }

        public void Shutdown()
        {
            Console.WriteLine("[Windows]: Shutdown...");
        }

        public void Start()
        {
            Console.WriteLine("[Windows]: Starting...");
        }
    }

    class G3 : Workstation
    {
        public G3(IOperatingSystem OperatingSystem)
            :base(OperatingSystem) {}
    }

    public class Abstract
    {
        public Abstract()
        {
            Console.WriteLine("==> Abstract");

            // Workstation w = new Workstation(); // Abstract class can't be instantiated.
            G3 g = new G3(new Windows()); // Class that contains Workstation and receives the OS on constructor.
            g.TurnOn();
            g.OperatingSystem.Boot();
            g.OperatingSystem.Start();
            g.OperatingSystem.Shutdown();
            g.TurnOff();

            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Abstract();
        }
    }
}