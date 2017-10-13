/*
 *    Filename: <mapping.cs>
 *
 * Description: Mapping interface to enable model persistence
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
using System.Linq;
using System.Collections.Generic;

namespace CSharp.DB
{
    public interface IMap<T> where T : class
    {
        IDbConnection Connection { get; set; }

        IDictionary<StatementEnum, IDbCommand> Commands { get; set; }

        IDictionary<string, string> DTO { get; set; }

        IDbCommand Get(StatementEnum statement);

        IDbCommand CreateCommand(CommandType type, string command_text, params KeyValuePair<string, DbType>[] parameters);

        KeyValuePair<string, DbType> CreateParameter(string name, DbType type);

        void GetConnection(IDbConnection connection);
    }

    public abstract class Map<T> : IMap<T> where T : class
    {
        public delegate void Mapping();

        public event Mapping OnMapping = null;

        public IDbConnection Connection { get; set; }

        public IDictionary<StatementEnum, IDbCommand> Commands { get; set; }
        public IDictionary<string, string> DTO { get; set; }

        public Map()
        {
            this.Commands = new Dictionary<StatementEnum, IDbCommand>();
            this.DTO = new Dictionary<string, string>();
        }

        public void GetConnection(IDbConnection connection)
        {
            this.Connection = connection;

            // altenative: dependency injection
            if (this.OnMapping != null)
                this.OnMapping.Invoke();
        }

        public IDbCommand CreateCommand(CommandType type, string command_text, params KeyValuePair<string, DbType>[] parameters)
        {
            var command  = this.Connection.CreateCommand(command_text, type);
            foreach (var param in parameters) 
                command.CreateParameter(param.Key, param.Value);
            return command;
        }

        public KeyValuePair<string, DbType> CreateParameter(string name, DbType type)
        {
            return new KeyValuePair<string, DbType>(name, type);
        }

        public IDbCommand Get(StatementEnum statement)
        {
            return this.Commands[statement];
        }
     }

    public class EmployeeMap : Map<Employee>
    {
        public EmployeeMap()
        {
            this.OnMapping += () =>
            {
                Commands.Add(StatementEnum.Select, CreateCommand(
                        CommandType.StoredProcedure, "USP_SELECT_EMPLOYEE", 
                        CreateParameter("@EmployeeId", DbType.Int32)));

                Commands.Add(StatementEnum.Insert, CreateCommand(
                        CommandType.StoredProcedure, "USP_INSERT_EMPLOYEE", 
                        CreateParameter("@Name", DbType.String),
                        CreateParameter("@Location", DbType.String)
                ));

                Commands.Add(StatementEnum.Update, CreateCommand(
                        CommandType.StoredProcedure, "USP_UPDATE_EMPLOYEE", 
                        CreateParameter("@EmployeeId", DbType.Int32),
                        CreateParameter("@Name", DbType.String),
                        CreateParameter("@Location", DbType.String)
                ));

                Commands.Add(StatementEnum.Delete, 
                        CreateCommand(CommandType.StoredProcedure, "USP_DELETE_EMPLOYEE", 
                        CreateParameter("@EmployeeId", DbType.Int32)));

                DTO.Add("EmployeeId", "@EmployeeId");
                DTO.Add("Name", "@Name");
                DTO.Add("Location", "@Location");
            };
        }
    }
}