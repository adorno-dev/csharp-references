/*
 *    Filename: <program.cs>
 *
 * Description: Fields, Properties
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.FieldsAndProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Property.Run();
            PropertyReadOnly.Run();
            PropertyWriteOnly.Run();
            AutoProperty.Run();
        }
    }
}
