/*
 *    Filename: <model.cs>
 *
 * Description: Models
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

namespace CSharp.DB
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Company Company { get; set; }
    }

    public class Company
    {
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}