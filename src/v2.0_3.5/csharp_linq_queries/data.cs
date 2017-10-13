/*
 *    Filename: <data.cs>
 *
 * Description: Data to be manipulated by LINQ
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
    public class Company
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
    }

    public class Data
    {
        public IQueryable<Company> Companies { get; set; }
        public IQueryable<Customer> Customers { get; set; }
  
        public Data()
        {
            this.Companies = new Company[]
            {
                new Company { Id = 1, Name = "Big Store", City = "New York", Country = "United States" },
                new Company { Id = 2, Name = "Mario World", City = "Las Vegas", Country = "United States" },
                new Company { Id = 3, Name = "Grand Prix", City = "Ottawa", Country = "Canada" },
                new Company { Id = 4, Name = "Unknwon Inc", City = "Tetbury", Country = "United Kingdom" },
                new Company { Id = 5, Name = "AnyWhere Info", City = "London", Country = "United Kingdom" }
            }.AsQueryable();

            this.Customers = new Customer[]
            {
                new Customer { Id = 1, CompanyId = 5, FirstName="Clubber", LastName="Lang" },
                new Customer { Id = 2, CompanyId = 4, FirstName="Jim", LastName="Carey" },
                new Customer { Id = 3, CompanyId = 3, FirstName="Ken", LastName="Thompson" },
                new Customer { Id = 4, CompanyId = 4, FirstName="Kennedy", LastName="Harrison" },
                new Customer { Id = 5, CompanyId = 2, FirstName="Samantha", LastName="Tompson" },
                new Customer { Id = 6, CompanyId = 4, FirstName="Andrew", LastName="Silent" },
                new Customer { Id = 7, CompanyId = 3, FirstName="Mark", LastName="Stanford" },
                new Customer { Id = 8, CompanyId = 1, FirstName="Kevin", LastName="Clark" },
                new Customer { Id = 9, CompanyId = 1, FirstName="Eric", LastName="Jones" },
                new Customer { Id = 10, CompanyId = 1, FirstName="John", LastName="Wayne" }
            }.AsQueryable();

            Console.WriteLine("=> Data (Loaded)");
        }
    }
}