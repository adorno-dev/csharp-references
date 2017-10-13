/*
 *    Filename: <serializable.cs>
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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CSharp.Serialization
{
    [Serializable, XmlRoot(Namespace="https://github.com/adorno-dev/csharp-references")]
    public class Person
    {
        private static int Identity = 0;

        [XmlAttribute]
        public bool canSerialize = true;
        [XmlAttribute]
        public bool canBeShared = false;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public DateTime MemberSince { get; set; }
        public DateTime LastAccess { get; set; }
        public List<Computer> Computers { get; set; }

        public Person() { this.Id = ++Identity; }

        public override string ToString()
        {
            return string.Format("Id: {0}\nFirstName: {1}\nLastName: {2}\nNickName: {3}\nMemberSince: {4}\nLastAccess: {5}\n",
                this.Id,
                this.FirstName,
                this.LastAccess,
                this.NickName,
                this.MemberSince,
                this.LastAccess);
        }
    }

    [Serializable]
    public class Computer
    {
        private static int Identity = 0;

        [NonSerialized]
        public int MemorySlots;
        [NonSerialized]
        public string ProcessorFamily;

        public int Id { get; set; }
        public float Memory { get; set; }
        public float Processor { get; set; }

        public List<OS> InstalledOS { get; set; }
        
        public Computer() { this.Id = ++Identity; }

        public override string ToString()
        {
            return string.Format("Id: {0}\nMemory: {1}\nProcessor: {2}\n",
                this.Id,
                this.Memory,
                this.Processor);
        }
    }

    [Serializable]
    public class OS
    {
        public string Architecture;
        [NonSerialized]
        public string Provider;

        public int Version { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("OperatingSystem: {0}\nVersion: {1}\nArchitecture: {2}\n",
                this.Description,
                this.Version,
                this.Architecture);
        }

    }

    [Serializable]
    public class Windows : OS
    {
        public string License { get; set; }
        public decimal Price { get; set; }

        public Windows() {}
    }

    [Serializable]
    public class Linux : OS
    {
        public string License { get; set; }
        public decimal Price { get; set; }

        public Linux() {}
    }

    [Serializable]
    public class MacOS : OS
    {
        public string License { get; set; }
        public decimal Price { get; set; }

        public MacOS() {}
    }

    [Serializable]
    public class Android : OS
    {
        public string License { get; set; }
        public decimal Price { get; set; }
        public Android() {}
    }
}
