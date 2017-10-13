/*
 *    Filename: <config.cs>
 *
 * Description: Generic configuration to NETCORE and .NET Framework
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Linq;
using System.Configuration;

#if (NETCOREAPP2_0)
using Microsoft.Extensions.Configuration;	
#endif

namespace CSharp.DB
{
	public class Config
	{
#if (NETCOREAPP2_0)
        private static IConfiguration config = new ConfigurationBuilder()
                      .SetBasePath(Environment.GetEnvironmentVariable("PWD"))
                      .AddXmlFile("app.config", false, true).Build();

		public static string Get(string entry)
        {
            return config.GetSection(entry).Value;
        }
#else
		public static string Get(string entry)
		{
			return ConfigurationManager.AppSettings.AllKeys.Any(w => w.Equals(entry)) ?
									   ConfigurationManager.AppSettings[entry] :
									   ConfigurationManager.ConnectionStrings[entry].ConnectionString;
		}
#endif
	}
}