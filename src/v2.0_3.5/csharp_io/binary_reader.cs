/*
 *    Filename: <binary_reader.cs>
 *
 * Description: Exposing the BinaryReader class
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections;
using System.IO;

namespace CSharp.IO 
{
    class BReader
    {
        public BReader()
        {
            this.Reader("binary.dat");
        }

        public void Reader(string filename)
        {
            var fd = new FileInfo(filename); // Opens the binary file descriptor.
            using (var br = new BinaryReader(fd.OpenRead()))
                Console.WriteLine("Code: {0}\nMessage: {1}\nDomain: {2}", 
                    br.ReadInt32(), 
                    br.ReadString(), 
                    br.ReadString());
        }

        public static void Run()
        {
            Console.WriteLine("=> BinaryReader"); new BReader();
            Console.WriteLine();
        }
    }
}