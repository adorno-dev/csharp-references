/*
 *    Filename: <delegate.cs>
 *
 * Description: Delegate examples
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
        public delegate void DoTurnOn();
        public delegate void DoTurnOff();
        public delegate void DoReset();

        // instancia dos delegates acima
        public DoTurnOn OnTurnOn;
        public DoTurnOff OnTurnOff;
        public DoReset OnReset;
    }
}