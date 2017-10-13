/*
 *    Filename: <interface.cs>
 *
 * Description: Indexing via interface
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Indexers
{
    interface ICByte
    {
        bool this [byte index] { get; set; }
    }

    struct CByte : ICByte
    {
        private sbyte bits;

        public bool this[byte index]
        {
            get { return (bits & (1 << index)) != 0; }
            set
            {
                if (value) // ativa ou desativa o bit
                    bits |= (sbyte) (1 << index);
                else
                    bits &= (sbyte) ~(1 << index);
            }
        }
    }

    public class Interface
    {
        public Interface()
        {
            Console.WriteLine("==> Interface");
        }

        public static void Run()
        {
            new Interface();
        }
    }
}