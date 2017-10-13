/*
 *    Filename: <selector_operator.cs>
 *
 * Description: Operator select in queries
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
    class SelectOperator
    {
        public SelectOperator()
        {
            var data = new Data();
            var customer_first_name = from c in data.Customers select c.FirstName;
            var customer_names = from c in data.Customers select new { c.FirstName, c.LastName };
            var companies = from c in data.Companies where c.City.Equals("United States") orderby c.Name select c.Name;
            var companies_grouped_by = from c in data.Companies group c by c.Country;
            var companies_count = (from c in data.Companies select c.Name).Count();
            var companies_distinct_count = (from c in data.Companies select c.Country).Distinct().Count();
            var customers_from = from c1 in data.Companies
                                 join c2 in data.Customers
                                 on c1.Id equals c2.CompanyId
                                 select new { c1.City, c2.FirstName, c2.LastName };
            
            foreach (var cf in customers_from)
                Console.WriteLine("From: {0} => {1}, {2}", cf.City, cf.LastName, cf.FirstName);
        }

        public static void Run()
        {
            Console.WriteLine("==> SelectOperator");
            new SelectOperator();
            Console.WriteLine();
        }
    }
}