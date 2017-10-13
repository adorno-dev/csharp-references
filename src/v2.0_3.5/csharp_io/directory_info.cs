/*
 *    Filename: <dictionary_info.cs>
 *
 * Description: Exposing the DirectoryInfo class
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
        public DirectoryInfo CurrentDirectory()
        {
            // Returns the current directory
            return new DirectoryInfo(".");
        }

        public DirectoryInfo ChangeDirectory(string directory)
        {
            // Change directory
            return new DirectoryInfo(directory);
        }

        public void CreateDirectory(string new_directory)
        {
            // Creates a new folder
            var not_found_directory = new DirectoryInfo(new_directory);
            not_found_directory.Create();
        }

        public DirectoryInfo CreateSubDirectory(string new_directory)
        {
            var current = new DirectoryInfo(".");
            var created = current.CreateSubdirectory(new_directory);
            this.DisplayDirectory(new_directory);
            return created;
        }

        public void DisplayDirectory(string directory)
        {
            System.IO.DirectoryInfo info = new DirectoryInfo(directory);

            Console.WriteLine(DIRECTORY_INFO, 
                              info.FullName, 
                              info.Name, 
                              info.Parent, 
                              info.CreationTime, 
                              info.Attributes, 
                              info.Root);
        }
    }
}