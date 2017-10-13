/*
 *    Filename: <join.cs>
 *
 * Description: Use of Join()
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
    class Join
    {
        public Join()
        {
            var data = new Data();
            var customers_from = data.Customers.Select(s => new { s.FirstName, s.LastName, s.CompanyId }) // <-- SELECT
                                               .Join(data.Companies, s1 => s1.CompanyId, s2 => s2.Id, // <-- JOIN (TABELA A JUNTAR, SETAR PK, SETAR FK)
                                                    (s1, s2) => new { s1.FirstName, s1.LastName, s2.City }); // <-- SELECT COM JUNCAO
            foreach (var customer_from in customers_from)
                Console.WriteLine("From: {0}, FullName: {1} {2}", customer_from.City, customer_from.FirstName, customer_from.LastName);
        }

        public static void Run()
        {
            Console.WriteLine("==> Join");
            new Join();
            Console.WriteLine();
        }
    }
}