/*
 *    Filename: <data_access.cs>
 *
 * Description: Generic DAL
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
using System.Data;
using System.Data.Common;
using System.Linq;

namespace CSharp.DB
{
    public interface IDAL<T> where T : class
    {
        void Insert(T inserted);
        void Update(T updated);
        void Delete(T deleted);
        IList<T> Select(T selected = null);
    }

    public static class DALExtension
    {
        public static IDbCommand ToOTD<T>(this IDbCommand command, T entity, IDictionary<string, string> dto)
        {
			if (entity != null)
	            command.Parameters.Cast<IDbDataParameter>()
	                              .ToList()
	                              .ForEach(param =>
	                              {
	                                  param.Value = entity.GetType()
	                                                      .GetProperty(dto.FirstOrDefault(w => w.Value.Equals(param.ParameterName)).Key)
	                                                      .GetValue(entity, null);
	                              });

            return command;
        }

        public static IList<T> ToDTO<T>(this IDbCommand command, IDictionary<string, string> dto)
        {
            IList<T> entities = new List<T>();

            IDataReader reader = null;

            try
            {
                command.Connection.Open();
                
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var entity = (T) Activator.CreateInstance(typeof(T));

                    foreach (var prop in dto.Keys)
                        entity.GetType()
                            .GetProperty(prop)
                            .SetValue(entity, reader.GetValue(reader.GetOrdinal(prop)), null);
                    
                    entities.Add(entity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                command.Connection.Close();
            }            

            return entities;
        }
    }

    public class DAL<T> : IDAL<T> where T : class
    {
		private IMap<T> Mapping { get; set; }

		public Adapter Adapter { get; set; }

        public DAL(IMap<T> mapping, IDbConnection connection)
        {
			// enable connected layer
			(this.Mapping = mapping).GetConnection(connection);

			// enable disconnected layer
			this.Adapter = connection.CreateAdapter();

			foreach (var statement in new[]
			{
				StatementEnum.Select,
				StatementEnum.Insert,
				StatementEnum.Update,
				StatementEnum.Delete
			})
			{
				typeof(Adapter).GetProperty(string.Format("{0}Command", statement))
				               .SetValue(this.Adapter, this.Mapping.Get(statement), null);
			}
        }

        public void Delete(T deleted)
        {
            this.Mapping.Get(StatementEnum.Delete).ToOTD(deleted, Mapping.DTO).NonQuery();
        }

        public void Insert(T inserted)
        {
            this.Mapping.Get(StatementEnum.Insert).ToOTD(inserted, Mapping.DTO).NonQuery();
        }

        public void Update(T updated)
        {
            this.Mapping.Get(StatementEnum.Update).ToOTD(updated, Mapping.DTO).NonQuery();
        }

        public IList<T> Select(T selected = null)
        {
			return Mapping.Get(StatementEnum.Select).ToOTD(selected, Mapping.DTO).ToDTO<T>(Mapping.DTO);
        }

		public IList<T> Select(object selected)
		{
			return Mapping.Get(StatementEnum.Select).ToOTD(selected, Mapping.DTO).ToDTO<T>(Mapping.DTO);
		}
	}
}