/*
 *    Filename: <arrays.cs>
 *
 * Description: How to work with arrays
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
    public class Array
    {
        public Array()
        {
            int[] arr = new int[4];
            
            int[] unknown;
            unknown = new int[4];

            Console.WriteLine("=> Array");
        }

        public void DynamicSize()
        {
            Console.Write("Please enter an array size: ");
            
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            while (--size >= 0)
                Console.WriteLine("Array Address {0}: {1}", size + 1, arr[size]);

            Console.WriteLine("=> Total Array Size: {0}", arr.Length);
            Console.WriteLine();
        }

        public void Create()
        {
            Console.WriteLine("=> Create");

            void Print(int[] arr)
            {
                Console.WriteLine("==> Printing Array");
                Console.Write("Array Name: {0} --> ", nameof(arr));

                int length = arr.Length;
                
                while (--length >= 0)
                    Console.Write("{0} ", arr[length]);
                
                Console.WriteLine();
            }

            int[,] table = new int[4, 6];
            
            int[] pins = new int[4] {3, 4, 5, 7};

            var r = new Random();

            int[] pins2 = new int[4]
            {
                r.Next() % 10,
                r.Next() % 10,
                r.Next() % 10,
                r.Next() % 10
            };

            int[] pins3 = {1, 3, 5, 7, 9, 11, 13, 15};

            TimeSpan[] schedule = { DateTime.Now.TimeOfDay, DateTime.Now.AddDays(2).TimeOfDay };

            Print(pins);
            Print(pins2);
            Print(pins3);

            Console.WriteLine();            
        }

        public void Create2()
        {
            var nicks = new[] { "John", "James", "Clark", "Billy" };

            var good = new[] { "John", "Billy" };

            var numbers = new[] { 1, 2, 3, 7.5, 77.77 };

            var subscribers = new[]
            {
                new { Name = "John", Age = 32 },
                new { Name = "James", Age = 27 },
                new { Name = "Clark", Age = 47 },
                new { Name = "Billy", Age = 57 }
            };

            Console.WriteLine("=> Create2");
            Console.WriteLine("==> Accesing Elements");

            Console.WriteLine("    Array Numbers");
            int? index = numbers.Length;
            Console.WriteLine("    Info: {0}, Type: {1}", nameof(numbers), numbers.GetType().Name);
            Console.WriteLine("    [Values]");
            while (--index >= 0)
                Console.WriteLine("    Index: {0}, Value: {1}", index + 1, numbers[index.Value]);

            Console.WriteLine();
            Console.WriteLine("    Throw Exception: ");
            
            try
            {
                Console.WriteLine(numbers[numbers.Length]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("    Code: {0} - Message: {1}", ex.HResult, ex.Message));
            }
            Console.WriteLine();

            Console.WriteLine("Foreach Array Objects");

            foreach (var p in subscribers)
                Console.WriteLine("Name: {0}, Age: {1}", p.Name, p.Age);

            Console.WriteLine();
        }

        public void Copy()
        {
            int[] nodes = { 1, 3, 5, 7 };
            int[] alias = nodes; // nodes e alias referenciam a mesma instancia de array

            // para copiar um array precisa primeiro instanciar o array de copia
            int[] copy1 = new int[4];
            int[] copy2 = new int[nodes.Length];
            int[] copy3 = null;

            for (int i = 0; i < copy1.Length; i++)
                copy1[i] = nodes[i];
            
            // metodos especializados
            nodes.CopyTo(copy1, 0);
            copy3 = (int[])nodes.Clone();
            
            System.Array.Copy(nodes, copy2, copy2.Length);
        }

        public static void Run()
        {
            var instance = new Array();
            // instance.DynamicSize();
            // instance.Create();
            // instance.Create2();
            // instance.Copy();
        }
    }
}