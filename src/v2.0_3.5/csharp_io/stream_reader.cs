/*
 *    Filename: <stream_reader.cs>
 *
 * Description: Exposing the StreamReader class
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
    class SReader
    {
        public SReader()
        {
            this.Reader();
        }

        public void Reader()
        {
            using (StreamReader sr = File.OpenText("reminders.txt"))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                    Console.WriteLine(line);
            }
        }

        public StreamReader Instantiate(string filename)
        {
            return new StreamReader(filename);
        }

        public static void Run()
        {
            Console.WriteLine("=> StreamReader"); new SReader();
            Console.WriteLine();
        }
    }
}