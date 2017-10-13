/*
 *    Filename: <filestream_async.cs>
 *
 * Description: Working with ASYNC FileStream
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
    class FileSystemAsync
    {
        public FileSystemAsync()
        {
            // Uses an overload method
            FileStream fs = new FileStream("log.txt", FileMode.Append, FileAccess.Write, FileShare.None, 4096, true);

            string message = "This file contains the results from 'filesystemasync' object";
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            void write_done(IAsyncResult result)
            {
                Console.WriteLine("AsyncCallback method on thread {0}", System.Threading.Thread.CurrentThread.GetHashCode());
                Stream s = (Stream) result.AsyncState; s.EndWrite(result); s.Close();
            }

            // Starts the method and put a callback functional that receives the IAsync result in -> void write_don(IAsyncResult result)
            fs.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(write_done), fs);
        }

        public static void Run()
        {
            Console.WriteLine("=> FileSystemAsync"); new FileSystemAsync();
            Console.WriteLine();
        }
    }
}