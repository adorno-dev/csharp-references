/*
 *    Filename: <soap_serializer.cs>
 *
 * Description: SOAP Serialization
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

#if NET20

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

// https://docs.microsoft.com/en-us/dotnet/standard/frameworks

// With .NET Framework in Mono

// To Compile: csc /t:exe /out:program.exe *.cs

namespace CSharp.Serialization
{
    class Soap
    {
        public Soap()
        {
            Person instance = new Person()
            {
                FirstName = "Adorno",
                LastName = "GNU",
                NickName = "Adorno GNU",
                MemberSince = DateTime.Now.AddYears(-1),
                LastAccess = DateTime.Now
            };

            this.Serialize<Person>(instance, "document.soap");
        }

        public void Serialize<T>(T data, string filename) where T : class
        {
            // Make Soap formatter
            SoapFormatter formatter = new SoapFormatter();

            // Stores in local file
            using (Stream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(s, data);
        }

        public static void Run()
        {
            Console.WriteLine("=> SoapFormatter"); new Soap();
            Console.WriteLine();
        }
    }
}
#endif