// using System;
// using System.Configuration;
// using System.Data;
// using System.Data.Common;
// using System.Data.SqlClient;

// namespace CSharp.DB
// {
//     public class SqlServer
//     {
//         public SqlServer()
//         {

//         }

//         public SqlConnection GetConnection()
//         {
//             SqlConnection connection = new SqlConnection();
//             connection.ConnectionString = ConfigurationManager.ConnectionStrings["sqlserver_workgroup"].ConnectionString;
//             return connection;
//         }

//         public SqlConnection GetConnection(string connectionString)
//         {
//             SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
//             SqlConnection connection = new SqlConnection(builder.ConnectionString);
//             return connection;
//         }
//     }

// }