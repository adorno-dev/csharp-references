/*
 *    Filename: <provider.cs>
 *
 * Description: Provider selector (returns connection strings from selected provider)
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
using System.Configuration;
using System.Data;
using System.Data.Common;

#if (NETCOREAPP2_0)
using Microsoft.Extensions.Configuration;
#endif

namespace CSharp.DB
{
    public enum ProviderEnum { SqlServer, OleDb, Odbc, Oracle, None }

	public class Provider
	{
#if (NETCOREAPP2_0)
		public static ProviderEnum Get()
        {
            switch (Config.Get("appSettings:add:value"))
            {
                case "System.Data.SqlClient": return ProviderEnum.SqlServer;
                case "System.Data.OracleClient": return ProviderEnum.Oracle;
                case "System.Data.OleDb": return ProviderEnum.OleDb;
                case "System.Data.Odbc": return ProviderEnum.Odbc;
            }
			return ProviderEnum.None;
        }
#else
		public static ProviderEnum Get()
		{
			switch (ConfigurationManager.AppSettings.Get("provider"))
			{
				case "System.Data.SqlClient": return ProviderEnum.SqlServer;
				case "System.Data.OracleClient": return ProviderEnum.Oracle;
				case "System.Data.OleDb": return ProviderEnum.OleDb;
				case "System.Data.Odbc": return ProviderEnum.Odbc;
			}
			return ProviderEnum.None;
		}	
#endif
	}
}