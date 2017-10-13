/*
 *    Filename: <parameter.cs>
 *
 * Description: Custom parameters and extensions
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
using System.Data.Common;

namespace CSharp.DB
{
    public enum StatementEnum { Select, Insert, Update, Delete, None }
       
    public static class ParameterExtension
    {
        public static void CreateParameter(this IDbCommand command, String name, DbType type, Object value = null)
        {
            var pm = command.CreateParameter();
            pm.ParameterName = name;
            pm.DbType = type;
            pm.Value = value;
            command.Parameters.Add(pm);
        }

		public static void CreateParameter(this IDbCommand command, String name, Object value)
		{
			switch (value.GetType().Name.ToLower())
			{
				case "int": case "int32": command.CreateParameter(name, DbType.Int32, value); break;
				case "string": command.CreateParameter(name, DbType.String, value); break;
				case "bool": case "boolean": command.CreateParameter(name, DbType.Boolean, value); break;
                case "double": command.CreateParameter(name, DbType.Double, value); break;
				case "decimal": command.CreateParameter(name, DbType.Decimal, value); break;
				case "long": case "int64": command.CreateParameter(name, DbType.Int64, value); break;
			}
		}

        public static void CreateParameter(this IDbCommand command, IDbDataParameter parameter)
        {
            command.CreateParameter(parameter);
        }

        public static void CreateParameters(this IDbCommand command, params IDbDataParameter[] parameters)
        {
            foreach (var parameter in parameters)
                command.Parameters.Add(parameter);
        }

        public static IDbDataParameter CreateParameter(this IDbConnection connection, String name, DbType type, Object value = null)
        {
            return connection.CreateParameter(name, type, value);
        }
    }
}