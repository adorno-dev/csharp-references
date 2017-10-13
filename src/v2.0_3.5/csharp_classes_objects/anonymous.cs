/*
 *    Filename: <anonymous.cs>
 *
 * Description: Illustrates anonymous object
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ClassesAndObjects
{
    public class Anonymous
    {
        public static void Run()
        {
            var myAnonymous_object = new
            {
                Http_Code = 404,
                Http_Message = "Page Not Found (404)"
            };

             Console.WriteLine("=> <Anonymous Type>");
             Console.WriteLine("Code: {0}, Message: {1}", myAnonymous_object.Http_Code, myAnonymous_object.Http_Message);
             Console.WriteLine();
        }
    }
}