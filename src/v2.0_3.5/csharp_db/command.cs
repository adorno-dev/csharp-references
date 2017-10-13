/*
 *    Filename: <commands.cs>
 *
 * Description: Generic command with extensions
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
using System.Collections;
using System.Collections.Generic;

namespace CSharp.DB
{
    public static class CommandExtension
    {
        public static IDbCommand CreateCommand(this IDbConnection connection, String text, CommandType type, Int32? timeout = null)
        {
            return new Command(connection)
                      .CreateCommand(text, type, timeout);
        }

        public static IDbCommand CreateCommand(this IDbConnection connection, String text, CommandType type, Int32? timeout = 777, params IDbDataParameter[] parameters)
        {
            var command = new Command(connection)
                             .CreateCommand(text, type, timeout);

            if (parameters != null && parameters.Length > 0)
                command.CreateParameters(parameters);

            return command;
        }

        public static int? NonQuery(this IDbCommand command)
        {
            int? command_result = null;

            try
            {
                command.Connection.Open();
                command_result = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }

            return command_result;
        }

        public static object Scalar(this IDbCommand command)
        {
            object command_result = null;

            try
            {
                command.Connection.Open();
                command_result = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                command.Connection.Close();
            }

            return command_result;
        }
    }

    public class Command
    {
        private IDbConnection connection = null;

        public Command(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IDbCommand CreateCommand(String text, CommandType type, Int32? timeout = null)
        {
            var command = connection.CreateCommand();
            command.CommandText = text;
            command.CommandType = type;
            
            if (timeout.HasValue)
                command.CommandTimeout = timeout.Value;
            
            return command;
        }
    }
}