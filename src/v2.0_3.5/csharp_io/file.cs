/*
 *    Filename: <file.cs>
 *
 * Description: Working with streams
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

namespace CSharp.IO
{
    public partial class IO 
    {
        public void CreateFile2(string filename)
        {
            using(FileStream fs = File.Create(filename)) return;
        }

        public void OpenFile2(string filename)
        {
            using(FileStream fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) return;
        }

        public void OpenReadOnlyFile(string filename)
        {
            using(FileStream fs_ro = File.OpenRead(filename)) return;
        }

        public void OpenReaderFile(string filename)
        {
            using(StreamReader sr = File.OpenText(filename)) return;
        }

        public void OpenWriterFile(string filename)
        {
            using(StreamWriter sw = File.CreateText(filename)) return;
        }

        public void OpenAppendFile(string filename)
        {
            using(StreamWriter sw = File.AppendText(filename)) return;
        }

        public void DeleteFile(string filename)
        {
            File.Delete(filename);
        }

        public void WriteAllLines(string filename, string[] lines)
        {
            File.WriteAllLines(filename, lines);
        }

        public void ReadAllLines(string filename)
        {
            var reader = File.ReadAllLines(filename).GetEnumerator();
            while (reader.MoveNext())
                Console.WriteLine(reader.Current);
        }
    }
}