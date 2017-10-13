/*
 *    Filename: <adapter.cs>
 *
 * Description: Custom adapter with dataset and other things
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
    public static class AdapterExtension
    {
        public static Adapter CreateAdapter(this IDbConnection connection)
        {
            return new Adapter(connection);
        }
    }

	public class Adapter : DbDataAdapter
	{
		private IDbCommand OriginalSelectCommand { get; set; }

		public IDbConnection Connection { get; private set; }

		public DataSet DataSet { get; set; }

		public Adapter(IDbConnection connection)
		{
			this.DataSet = new DataSet();
			this.Connection = connection;
		}

		// providers with distinct features (eg. SQLSERVER -> @Parameter)
		private string GetProviderParameter(string parameter)
		{
			switch (Provider.Get())
			{
				case ProviderEnum.SqlServer: return String.Format("@{0}", parameter);
			}

			return parameter;
		}

		private void ChangeSelectCommand(IDbCommand command)
		{
			this.GetType()
				.GetProperty("SelectCommand")
				.SetValue(this, command);
		}

		public DataSet Fill()
		{
			this.Fill(this.DataSet);

			if (this.OriginalSelectCommand != null)
			{
				this.ChangeSelectCommand(this.OriginalSelectCommand);
				this.OriginalSelectCommand = null;
			}

			return this.DataSet;
		}

		public DataSet Update()
		{
			this.Update(this.DataSet);

			return this.DataSet;
		}

		public DataSet Select(string command_text = null, object selected = null)
		{
			if (string.IsNullOrEmpty(command_text))
				return this.Fill();

			if (this.OriginalSelectCommand == null)
				this.OriginalSelectCommand = this.SelectCommand;

			this.ChangeSelectCommand(this.Connection.CreateCommand(command_text, CommandType.StoredProcedure));

			foreach (var parameter in selected.GetType().GetProperties())
				this.SelectCommand.CreateParameter(
					 GetProviderParameter(parameter.Name), selected.GetType()
	 				.GetProperty(parameter.Name).GetValue(selected, null));

			return this.Fill();
		}
	}
}