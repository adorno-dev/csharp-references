/*
 *    Filename: <stream_writer.cs>
 *
 * Description: Exposing the StreamWriter class
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
    class SWriter
    {
        public SWriter()
        {
            this.Write();
        }

        public void Write()
        {
            using (StreamWriter sw = File.CreateText("reminders.txt"))
            {
                sw.WriteLine("Don't forget to dispose this object.");
                sw.WriteLine("Write something here and then be happy!");
                sw.Write(sw.NewLine);
                sw.WriteLine("Cheers.");
            }
        }

        public StreamWriter Instantiate(string filename)
        {
            return new StreamWriter(filename);
        }

        public static void Run()
        {
            Console.WriteLine("=> StreamWriter"); new SWriter();
            Console.WriteLine();
        }
    }
}