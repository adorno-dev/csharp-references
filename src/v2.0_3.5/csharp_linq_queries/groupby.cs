/*
 *    Filename: <groupby.cs>
 *
 * Description: Use of GroupBy()
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
    class GroupBy
    {
        public GroupBy()
        {
            var data = new Data();
            var companies_by_country = data.Companies.GroupBy(g => g.Country);

            foreach (var by_contry in companies_by_country)
            {
                Console.WriteLine("From Country: {0} ({1})", by_contry.Key, by_contry.Count());

                foreach (var company in by_contry)
                    Console.WriteLine("==> CompanyName: {0}", company.Name);
            }
        }

        public static void Run()
        {
            Console.WriteLine("==> GroupBy");
            new GroupBy();
            Console.WriteLine();
        }
    }
}