/*
 *    Filename: <file_info.cs>
 *
 * Description: Working with files
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
using System.Collections.Generic;
using System.IO;

namespace CSharp.IO
{
    public partial class IO 
    {
        public IEnumerable<FileInfo> GetFiles(string directory)
        {
            var info = new System.IO.DirectoryInfo(directory);

            // return info.GetFiles(); <-- Returns all files from directory

            return info.GetFiles("*.cs"); // <-- Returns filtered files in directory
        }

        public void CreateFile(string filename)
        {
            var f = new FileInfo(filename);
            using (var s = f.Create()) return;
        }

        public void OpenFile(string filename)
        {
            var f = new FileInfo(filename);
            using (var s = f.Open(FileMode.Open | FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) return;
        }

        public void OpenReadFile(string filename)
        {
            var f = new FileInfo(filename);
            using (var s = f.OpenRead()) return;
        }

        public void OpenWriteFile(string filename)
        {
            var f = new FileInfo(filename);
            using (var s = f.OpenWrite()) return;            
        }

        public void CreateTextFile(string filename)
        {
            var f = new FileInfo(filename);
            using (var s = f.CreateText())
                s.WriteLine("this is an empty file.");
        }

        public void AppendTextFile(string filename)
        {
            var f = new FileInfo(filename);
            using (var s = f.AppendText())
                for (int i = 0; i < 10; i++)
                    s.WriteLine("this line is {0}", i);
        }

        public void DisplayFiles(string directory)
        {
            var reader = this.GetFiles(directory).GetEnumerator();

            while(reader.MoveNext())
            {
                System.IO.FileInfo info = (FileInfo) reader.Current;

                Console.WriteLine(FILE_INFO,
                                  info.Name,
                                  info.Length,
                                  info.CreationTime,
                                  info.Attributes);
            }
        }
    }
}