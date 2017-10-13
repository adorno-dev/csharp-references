/*
 *    Filename: <collection.cs>
 *
 * Description: How to work with Collections 
 *              => ArrayList, Queue, Stack, Hashtable and SortedList
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ArraysAndCollections
{
    public class Collection
    {
        public Collection()
        {
            Console.WriteLine("=> Collection");
        }

        public static void Run()
        {
            ArrayList.Run();
            Queue.Run();
            Stack.Run();
            Hashtable.Run();
            SortedList.Run();
        }
    }
}