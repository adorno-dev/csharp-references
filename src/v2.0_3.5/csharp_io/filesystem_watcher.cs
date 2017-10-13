/*
 *    Filename: <filesystem_watcher.cs>
 *
 * Description: FileSystemWatcher usages
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example extracted from C# step by step (2008)
 
 */

using System;
using System.Collections;
using System.IO;

namespace CSharp.IO 
{
    class Watcher
    {
        public Watcher()
        {
            FileSystemWatcher instance = new FileSystemWatcher();
            
            try
            {
                instance.Path = "/tmp/vms/caching/bootstrap";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message); return;
            }

            // Setup notifications
            instance.NotifyFilter = NotifyFilters.LastAccess 
                                  | NotifyFilters.LastWrite 
                                  | NotifyFilters.FileName
                                  | NotifyFilters.DirectoryName;
            

            // Filter usage
            instance.Filter = "*";

            // Event handlers
            instance.Changed += (object source, FileSystemEventArgs args) => { Console.WriteLine("File: {0} {1}", args.FullPath, args.ChangeType); };
            instance.Created += (object source, FileSystemEventArgs args) => { Console.WriteLine("File: {0} {1}", args.FullPath, args.ChangeType); };
            instance.Deleted += (object source, FileSystemEventArgs args) => { Console.WriteLine("File: {0} {1}", args.FullPath, args.ChangeType); };
            instance.Renamed += (object source, RenamedEventArgs args) => { Console.WriteLine("File: {0} renamed to {1}", args.OldFullPath, args.FullPath); };

            // Flag to start event handlers
            instance.EnableRaisingEvents = true;

            Console.WriteLine(@"Press 'q' to quit."); while (Console.Read()!='q');
        }

        public static void Run()
        {
            Console.WriteLine("=> FileSystemWatcher"); new Watcher();
            Console.WriteLine();
        }
    }
}