/*
 *    Filename: <select.cs>
 *
 * Description: Use of Select()
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.LinqQueries
{
    class Select
    {
        public Select()
        {
            var data = new Data();
            // var customer_names = data.Customers.Select(s => s.FirstName); // <-- SELECT
            // var customer_names = data.Customers.Select(s => string.Format("{0} {1}", s.FirstName, s.LastName)); // <-- SELECT
            var people = data.Customers.Select(s => new { FirstName = s.FirstName, LastName = s.LastName }); // <-- SELECT

            // foreach (string name in customer_names)
                // Console.WriteLine("Full Name: {0}", name);
            
            foreach (var person in people)
                Console.WriteLine("Full Name: {0} {1}", person.FirstName, person.LastName);
        }

        public static void Run()
        {
            Console.WriteLine("==> Select");
            new Select();
            Console.WriteLine();
        }
    }
}