/*
 *    Filename: <polymorphism.cs>
 *
 * Description: Polymorphism
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
    class OperatingSystem
    {
        public virtual string GetOS()
        {
            return "[Operating System Not Found]";
        }
    }

    class MacOS : OperatingSystem
    {
        public override string GetOS()
        {
            return "MacOS El Captain Installed";
        }
    }

    class Windows : OperatingSystem
    {
        public override string GetOS()
        {
            return "Windows 10 Ultimate Installed";
        }
    }

    class Linux : OperatingSystem
    {
        public override string GetOS()
        {
            return "Linux - Ubuntu 16.04 LTS Installed";
        }
    }

    public class Polymorphism
    {
        public Polymorphism()
        {
            Console.WriteLine("==> Polymorphism (Virtual Methods)");

            Linux os1 = new Linux();
            Windows os2 = new Windows();
            MacOS os3 = new MacOS();
            OperatingSystem os;

            os = os1; Console.WriteLine("Computer says: {0}", os.GetOS()); // Linux
            os = os2; Console.WriteLine("Computer says: {0}", os.GetOS()); // Windows
            os = os3; Console.WriteLine("Computer says: {0}", os.GetOS()); // MacOS

            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Polymorphism();
        }
    }
}