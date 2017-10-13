/*
 *    Filename: <filestream.cs>
 *
 * Description: Working with FileStream
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
using System.Text;

namespace CSharp.IO
{
    public partial class IO 
    {
        public void RunFileStreamExample1()
        {
            using (FileStream fs = File.Open("filestream.example1.txt", FileMode.Create))
            {
                Console.WriteLine();
                
                // Coding to bytes array
                string message = "Welcome C#";
                byte[] message_as_byte_array = Encoding.Default.GetBytes(message);

                // Write the bytes array to file
                fs.Write(message_as_byte_array, 0, message_as_byte_array.Length);

                // Reset the internal position of stream
                fs.Position = 0;

                // Loads the byte arrays from control to buffer
                Console.WriteLine("Your message as an array of bytes: ");
                byte[] bytes_from_file = new byte[message_as_byte_array.Length];
                for (int i = 0; i < message_as_byte_array.Length; i++)
                {
                    bytes_from_file[i] = (byte)fs.ReadByte();
                    Console.Write(bytes_from_file[i]);
                }

                // Show the message encoded/decoded
                Console.WriteLine("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytes_from_file));
            }
        }
    }
}