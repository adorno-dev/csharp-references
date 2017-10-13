/*
 *    Filename: <directory.cs>
 *
 * Description: Exposing the Directory class
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
    public partial class IO 
    {
        public string[] GetLogicalDrivers()
        {
            return Directory.GetLogicalDrives();
        }

        public void DeleteDirectory(string directory)
        {
            Directory.Delete(path: directory, recursive: false);
        }

        public void DisplayLogicalDrivers()
        {
            IEnumerator reader = this.GetLogicalDrivers().GetEnumerator();
            
            while (reader.MoveNext())
                Console.WriteLine("{0} ", reader.Current);
        }
    }
}