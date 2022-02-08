using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public abstract class DataQueryContext : DataContext
    {

        protected DataQueryContext(DbConnection connection) : base(connection)
        {
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return ExecuteQuery<T>(CreateCommand(sql, CommandType.Text));
        }

        public IEnumerable<T> Query<T>(string sql, IEnumerable<DataParameter> parameters)
        {
            return ExecuteQuery<T>(CreateCommand(sql, parameters, CommandType.Text));
        }

        private IEnumerable<T> ExecuteQuery<T>(DbCommand command)
        {
            try
            {
                Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.Parse<T>();
                }
            }
            finally
            {
                Close();
            }
        }
    }
}
