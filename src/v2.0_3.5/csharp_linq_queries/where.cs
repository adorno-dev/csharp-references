/*
 *    Filename: <where.cs>
 *
 * Description: Use of Where()
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
    class Where
    {
        public Where()
        {
            var data = new Data();
            var companies = data.Companies.Where(w => w.Country.Equals("United States")).Select(s => s.Name);

            foreach (var company in companies)
                Console.WriteLine("=> CompanyName: {0}", company);
        }

        public static void Run()
        {
            Console.WriteLine("==> Where");
            new Where();
            Console.WriteLine();
        }
    }
}