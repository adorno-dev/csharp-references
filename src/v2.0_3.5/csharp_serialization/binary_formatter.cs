/*
 *    Filename: <binary_formatter.cs>
 *
 * Description: Binary Serialization
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp.Serialization
{
    class Binary
    {
        public Binary()
        {
            Person instance = new Person()
            {
                FirstName = "Adorno",
                LastName = "GNU",
                NickName = "Adorno GNU",
                MemberSince = DateTime.Now.AddYears(-1),
                LastAccess = DateTime.Now
            };

            this.Serialize<Person>(instance, "binary.bin");
            this.Deserialize<Person>("binary.bin");
        }

        public void Serialize<T>(T data, string filename) where T : class
        {
            // Make binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Stores in local file
            using (Stream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(s, data);
        }

        public void Deserialize<T>(string filename) where T : class
        {
            // Make binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Reads from local file
            using (Stream s = File.OpenRead(filename))
                Console.WriteLine("==> Deserialized:\n{0}", formatter.Deserialize(s));
            
            File.Delete(filename);
        }

        public static void Run()
        {
            Console.WriteLine("=> BinaryFormatter"); new Binary();
            Console.WriteLine();
        }
    }
}