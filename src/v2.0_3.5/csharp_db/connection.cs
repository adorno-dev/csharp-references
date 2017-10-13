/*
 *    Filename: <connection.cs>
 *
 * Description: Generic connection to NETCORE and .NET Framework
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
using System.Data.OracleClient;
using System.Data.SqlClient;

#if (!NETCOREAPP2_0)
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
#endif

namespace CSharp.DB
{
    public static class Connection
    {
        public static IDbConnection CreateConnection(ProviderEnum provider, string connection_string)
        {
            var connection = CreateConnection(provider);
            connection.ConnectionString = connection_string; 
            return connection;
        }

        public static IDbConnection CreateConnection(ProviderEnum provider)
        {
            switch (provider)
            {
				case ProviderEnum.Oracle: return new OracleConnection(ConnectionString.Get(provider));
				case ProviderEnum.SqlServer: return new SqlConnection(ConnectionString.Get(provider));

                #if (!NETCOREAPP2_0)

                    case ProviderEnum.OleDb: return new OleDbConnection(ConnectionString.Get(provider));
                    case ProviderEnum.Odbc: return new OdbcConnection(ConnectionString.Get(provider));

                #endif
            }

            return new SqlConnection(ConnectionString.Get(provider)); // SQL Server as default
        }

        public static IDbConnection CreateConnection()
        {
            return CreateConnection(Provider.Get());
        }
    }
}