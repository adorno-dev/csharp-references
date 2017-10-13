/*
 *    Filename: <binary_writer.cs>
 *
 * Description: Exposing the BinaryWriter class
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
    class BWriter
    {
        public BWriter()
        {
            this.Write("binary.dat");
        }

        public void Write(string filename)
        {
            var fd = new FileInfo(filename); // Open the binary file descriptor.
            using (var bw = new BinaryWriter(fd.OpenWrite()))
            {
                // Show the kind of BaseStream. (System.IO.FileStream)
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);

                // Data to store in binary format.
                int code = 404;
                string message = "Page Not Found";
                string domain = "https://github.com/adorno-dev";

                // Writes the data
                bw.Write(code);
                bw.Write(message);
                bw.Write(domain);
            }
        }

        public static void Run()
        {
            Console.WriteLine("=> BinaryWriter"); new BWriter();
            Console.WriteLine();
        }
    }
}