/*
 *    Filename: <program.cs>
 *
 * Description: Serialization
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Binary.Run();

            #if NET20

            Soap.Run();
            
            #endif

            Xml.Run();
        }
    }
}
