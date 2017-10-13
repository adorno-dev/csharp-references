/*
 *    Filename: <xml_serializer.cs>
 *
 * Description: XML Serialization
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections.Generic;
using System.IO;

using System.Xml.Serialization;

// https://docs.microsoft.com/en-us/dotnet/standard/frameworks

// With .NET Framework in Mono

// To Compile: csc /t:exe /out:program.exe *.cs

namespace CSharp.Serialization
{
    class Xml
    {
        public Xml()
        {
            Person instance = new Person()
            {
                FirstName = "Adorno",
                LastName = "GNU",
                NickName = "Adorno GNU",
                MemberSince = DateTime.Now.AddYears(-1),
                LastAccess = DateTime.Now,
                Computers = new List<Computer>()
                {
                    new Computer()
                    {
                        Memory = 8.0F,
                        Processor = 4.0F,
                        MemorySlots = 4,
                        ProcessorFamily = "Core 2 Quad",
                        InstalledOS = new List<OS>()
                        {
                            new OS { Architecture = "X64", Description = "Ubuntu 16.04 LTS" },
                            new OS { Architecture = "Intel X86", Description = "Android L" }
                        }
                    }
                }
            };

            this.Serialize<Person>(instance, "document.xml");
        }

        public void Serialize<T>(T data, string filename) where T : class
        {
            // Make Xml formatter
            XmlSerializer formatter = new XmlSerializer(typeof(T), new Type[] { typeof(Linux) });
            // XmlSerializer formatter = new XmlSerializer(typeof(T), "CSharp.Serializer");

            // Stores in local file
            using (Stream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(s, data);
        }

        public static void Run()
        {
            Console.WriteLine("=> XmlFormatter"); new Xml();
            Console.WriteLine();
        }
    }
}