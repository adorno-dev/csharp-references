/*
 *    Filename: <paramcs.cs>
 *
 * Description: How to work with parameters
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.ArrayAndParameters
{
    public struct Person
    {
        private static int identity = 0;

        public string Name { get; set; }
        public int Id { get; private set; }       

        public Person(string name)
        {
            this.Name = name;
            this.Id = ++identity;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", this.Id, this.Name);
        }
    }

    public class Params
    {
        public Params()
        {
            int min_by2 = this.Min(1, 3);
            int min_by3 = this.Min(-1, -3, 5, 7);

            Console.WriteLine("=> Params");
            Console.WriteLine("Two: Min = {0}", min_by2);
            Console.WriteLine("Three: Min -> {0}", min_by3);
            Console.WriteLine();

            People(
                new Person("John"),
                new Person("Peter"),
                new Person("Paul")
            );
        }

        public int Min(params int[] param_list) // <-- array params doesn't works with bidimentional, overload, refs and outs etc..
        {
            int? current = null;

            if (param_list == null || param_list.Length == 0)
                throw new ArgumentException("Not enough arguments.");
            else
                current = param_list[0];

            foreach (int value in param_list)
                if (value < current)
                    current = value;
            
            return current.Value;
        }

        public void People(params object[] people)
        {
            Console.WriteLine("==> Params (People)");

            foreach (var person in people)
                Console.WriteLine(person);

            Console.WriteLine();
        }

        public static void Run()
        {
            var instance = new Params();
        }
    }
}