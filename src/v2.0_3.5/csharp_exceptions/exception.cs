/*
 *    Filename: <exception.cs>
 *
 * Description: Working with exceptions
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example extracted from book C# step by step (2008)
 *
 */

using System;

namespace CSharp.Exceptions
{
    class Microcode
    {
        public void Automate(bool on)
        {
            if (on)
                Console.WriteLine("Automatic Mode...");
            else
                Console.WriteLine("Manual Mode...");
        }
    }

    class CPU
    {
        public readonly int MAXOVERCLOCK = 120;

        private Microcode microcode = new Microcode();
        private int rate;
        private string identifier;
        private bool activated;       

        public CPU() {}
        public CPU(string identifier, int rate)
        {
            this.identifier = identifier;
            this.rate = rate;
        }

        public void SetAutomatic(bool state)
        {
            this.microcode.Automate(state); // delegates request to internal object
        }

        public void SetOverclock(int rate)
        {
            if (rate < 0)
                throw new ArgumentException("Frequency rate must be greater than zero!");

            if (this.activated)
                Console.WriteLine("{0} is out of range...", this.identifier);
            else
            {
                this.rate += rate;
                if (this.rate > MAXOVERCLOCK)
                {
                    // Console.WriteLine("The CPU: {0} is burning!", this.identifier);
                    this.rate = 0;
                    this.activated = false;

                    // throw new Exception(string.Format("{0} has overheated!", this.identifier)); // <-- throw (used to gen an exception)
                    var exception = new Exception(string.Format("{0} has overheated!", this.identifier)) { HelpLink = "https://www.someurl.com" }; // <-- throw exception details

                    // Include more data into exception
                    exception.Data.Add("Timestamp", DateTime.Now);
                    exception.Data.Add("Details", string.Format("The CPU {0} is burning!", this.identifier));
                    exception.Data.Add("Cause", "You need to buy other CPU.");

                    // throw exception;

                    throw new CPUOverclockException("Overclock exceed the limit!", "Unsupported Ratio", DateTime.Now);
                }
                else
                    Console.WriteLine("=> Frequency Rate: {0}Mhz", this.rate);
            }
        }

        public static void Run()
        {
            CPU cpu = new CPU("Core2Duo", 70);

            cpu.SetAutomatic(false);

            try
            {
                for (int i = 0; i < 10; i++) // force overclock limit
                    cpu.SetOverclock(-10);
            }
            catch (ArgumentOutOfRangeException ea)
            {
                Console.WriteLine("Method: {0}", ea.TargetSite);
                Console.WriteLine("Message: {0}", ea.Message);
            }
            catch (CPUOverclockException ec)
            {
                Console.WriteLine("Cause: {0} At {1}", ec.Cause, ec.Timestamp);
                Console.WriteLine("==> {0}", ec.Message);
            }
            catch (Exception e) // forcar captura de excecao
            {
                Console.WriteLine("\n*** Error! ***");
                Console.WriteLine("Method: {0}", e.TargetSite); // details about the method (readonly)
                Console.WriteLine("Message: {0}", e.Message);   // an textual message (readonly)
                Console.WriteLine("Message: {0}", e.Source);    // assembly name throws exception
                Console.WriteLine("Stack: {0}", e.StackTrace);  // stack info until the caller

                Console.WriteLine("Timestamp: {0}", e.Data["Timestamp"]);
                Console.WriteLine("Cause: {0}", e.Data["Cause"]);
            }

            // continue execution because  it isn't manipulated..
        }
    }
}