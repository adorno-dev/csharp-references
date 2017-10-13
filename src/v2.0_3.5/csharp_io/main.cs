/*
 *    Filename: <main.cs>
 *
 * Description: This file contains the main class.
 *              Calling the other files to show IO features.
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
        private readonly string DIRECTORY_INFO = "Fullname: {0}\nName: {1}\nParent: {2}\nCreation: {3}\nAttributes: {4}\nRoot: {5}\n";
        private readonly string FILE_INFO = "Filename: {0}\nFile Size: {1}\nCreation: {2}\nAttributes: {3}\n";
        private readonly string LOGICAL_DRIVE_INFO = "Name: {0}\nType: {1}\nFree Space: {2}\nFormat: {3}\nLabel: {4}\n";

        public IO()
        {
            // this.DisplayDirectory(".");
            // this.DisplayFiles(".");
            // this.DisplayLogicalDrivers();
            // this.DisplayDrivers();

            // this.CreateSubDirectory("trash");
            // this.DeleteDirectory("trash");
            // this.CreateTextFile("readme.txt");
            // this.AppendTextFile("readme.txt");
            // this.DeleteFile("readme.txt");
            
            // this.WriteAllLines("tasks.txt", new[] { "Languages", "C", "C#", "Python", "HTML5", "CSS3", "Javascript ES6" });
            // this.ReadAllLines("tasks.txt");

            // this.RunFileStreamExample1(); // exemplo com FileStream e array de bytes

            // SWriter.Run(); // StreamWriter
            // SReader.Run(); // StreamReader

            // BWriter.Run(); // BinaryWriter
            // BReader.Run(); // BinaryReader

            // FileSystemAsync.Run(); // escreve arquivo de forma asincrona
            
            // this.DeleteFile("log.txt");
            // this.DeleteFile("tasks.txt");
            // this.DeleteFile("filestream.example1.txt");
            // this.DeleteFile("reminders.txt");
            // this.DeleteFile("binary.dat");
            
            Watcher.Run(); // initializa o monitoramento do diretorio
        }

        public static void Run()
        {
            Console.WriteLine("=> IO"); new IO();
            Console.WriteLine();
        }
    }
}