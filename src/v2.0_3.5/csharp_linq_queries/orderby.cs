/*
 *    Filename: <orderby.cs>
 *
 * Description: Use of OrderBy()
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
    class OrderBy
    {
        public OrderBy()
        {
            var data = new Data();
            var companies = data.Companies.OrderBy(o => o.Name).Select(s => s.Name);

            foreach (var company in companies)
                Console.WriteLine("=> CompanyName: {0}", company);
        }

        public static void Run()
        {
            Console.WriteLine("==> OrderBy");
            new OrderBy();
            Console.WriteLine();
        }
    }
}