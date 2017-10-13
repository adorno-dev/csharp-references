/*
 *    Filename: <connection_string.cs>
 *
 * Description: Generic connection string to NETCORE and .NET Framework
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;

namespace CSharp.DB
{
	public class ConnectionString
	{
		public static string Get(ProviderEnum provider)
		{
#if (!NETCOREAPP2_0)
			return Config.Get(
				   String.Format("{0}_workgroup", provider.ToString().ToLower()));
#else
			return Config.Get(
				   String.Format("connectionStrings:add:{0}_workgroup:connectionString", provider.ToString().ToLower()));
#endif
		}

        public static string Get()
        {
            return Get(Provider.Get());
        }
    }
}