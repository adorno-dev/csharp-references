/*
 *    Filename: <class.cs>
 *
 * Description: Classes using delegates
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.EventDelegates
{
    public partial class Computer
    {
        public void TurnOn() 
        {
            if (this.OnTurnOn != null)
                this.OnTurnOn.Invoke();
            
            Console.WriteLine("[From Method]: Turn On");
        }

        public void TurnOff() 
        {
            if (this.OnTurnOff != null)
                this.OnTurnOff.Invoke();

            Console.WriteLine("[From Method]: Turn Off");
        }

        public void Reset() 
        {
            if (this.OnReset != null)
                this.OnReset.Invoke();

            Console.WriteLine("[From Method]: Reset");
        }

        private void Log()
        {
            Console.WriteLine("[From Logger][Internal]: Invoked!");
        }

        public Computer() 
        {
            // acessando os eventos internamente
            this.OnTurnOn += this.Log;
            this.OnTurnOff += this.Log;
            this.OnReset += this.Log;
        }
    }

    public class App
    {
        public App()
        {
            Console.WriteLine("==> Event Delegates");
            Computer instance = new Computer();

            // acessando os eventos externamente
            instance.OnTurnOn += () => { Console.WriteLine("[From delegate][External]: OnTurnOn"); };
            instance.OnTurnOff += () => { Console.WriteLine("[From delegate][External]: OnTurnOff"); };
            instance.OnReset += () => { Console.WriteLine("[From delegate][External]: OnReset"); };

            instance.TurnOn();
            instance.Reset();
            instance.TurnOff();
        }

        public static void Run()
        {
            new App();
        }
    }
}