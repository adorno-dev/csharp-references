/*
 *    Filename: <program.cs>
 *
 * Description: How to work with databases (only stored procedures)
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.DB
{
    class Program
    {
        // TODO: Load child properties

        #region +Entry
        
        static void Main(string[] args)
        {
            var resource = new DAL<Employee>(new EmployeeMap(), Connection.CreateConnection());

            #region +Connected Layer

            resource.Insert(new Employee { Name = "Steve", Location = "United States" });
            resource.Update(new Employee { EmployeeId = 5, Name = "Steve", Location = "Brazil (Migrated)" });
            resource.Delete(new Employee { EmployeeId = 1 });
            resource.Select()                    
                    .ToList()
                    .ForEach(s => Console.WriteLine("Key: {0} Name: {1} - Location: {2}", s.EmployeeId, s.Name, s.Location));
            
            #endregion

            #region +Disconnected Layer

            resource.Adapter.Select("USP_INFO", new { Model = "Employee" }); // common stored procedure

            resource.Adapter.DataSet.Tables[0].Rows.Cast<DataRow>()
                                                   .ToList()
                                                   .ForEach(r => Console.WriteLine("=> Stored Procedures: {0}", r[1]));
            
            // ~ We can change the datatables and call resource.Adapter.Update()

            #endregion
        }

        #endregion
    }
}
