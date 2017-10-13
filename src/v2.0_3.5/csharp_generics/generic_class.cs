/*
 *    Filename: <generic_class.cs>
 *
 * Description: Generic Class
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 *       Notes: Example extracted from book C# step by step (2008)
 */

using System;
using System.Collections.Generic;

namespace CSharp.Generics
{
    class Person 
    { 
        private static int _internal_id = 0;
        
        public int Id { get; set;  } 
        public string Name { get; set; } 

        public Person() { this.Id = ++_internal_id; }

        public override string ToString()
        {
            return string.Format("Id: {0}\nName: {1}\n", this.Id, this.Name);
        }
    }

    class Persistence<T>
    {
        private Dictionary<string, T> people = null;

        public Persistence()
        {
            this.people = new Dictionary<string, T>();
        }

        public void Insert(string key, T value)
        {
            this.people.Add(key, value);

            Console.WriteLine("Inserted: {0}", key);
        }

        public void Delete(string key)
        {
            this.people.Remove(key);

            Console.WriteLine("Deleted: {0}", key);
        }

        public void List()
        {
            Console.WriteLine("==> List\n");

            foreach (var p in this.people)
                Console.WriteLine(p);
        }
    }

    public class GenericClass
    {
        public GenericClass()
        {
            Console.WriteLine("==> Generic Class");

            Persistence<Person> p = new Persistence<Person>();
            p.Insert("James", new Person { Name = "James" });
            p.Insert("Charlie", new Person { Name = "Charlie" });
            p.Insert("Clark", new Person { Name = "Clark" });
        }

        public static void Run()
        {
            new GenericClass();
        }
    }

}