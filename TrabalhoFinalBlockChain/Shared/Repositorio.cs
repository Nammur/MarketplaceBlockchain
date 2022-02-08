using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public abstract class Repositorio
    {
        public DataTransactionContext _dataTransactionContext { get; private set; }

        public Repositorio(DataTransactionContext dataTransactionContext)
        {
            _dataTransactionContext = dataTransactionContext;
        }

        protected int Execute(string sql, IEnumerable<DataParameter> parameters, CommandType commandType = CommandType.Text)
        {
            return Execute(sql, parameters, 0, commandType);
        }

        protected int Execute(string sql, IEnumerable<DataParameter> parameters, int timeout, CommandType commandType = CommandType.Text)
        {
            using (var connection = _dataTransactionContext.GetNewConnection())
            {
                SetSessionContext(connection);

                var command = connection.CreateCommand();
                command.CommandTimeout = timeout == 0 ? 300 : timeout;
                command.CommandText = sql;
                command.CommandType = commandType;

                if (parameters != null)
                    foreach (var param in parameters)
                        command.Parameters.Add(_dataTransactionContext.GetParatemer(param.Name, param.Value ?? DBNull.Value));

                if (connection.State != ConnectionState.Open) connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        protected T ExecuteScalar<T>(string sql, IEnumerable<DataParameter> parameters, CommandType commandType = CommandType.Text)
        {
            using (var connection = _dataTransactionContext.GetNewConnection())
            {
                SetSessionContext(connection);

                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = commandType;

                if (parameters != null)
                    foreach (var param in parameters)
                        command.Parameters.Add(_dataTransactionContext.GetParatemer(param.Name, param.Value ?? DBNull.Value));

                if (connection.State != ConnectionState.Open) connection.Open();

                return (T)command.ExecuteScalar();
            }
        }

        protected IEnumerable<T> Query<T>(string sql, int CommandTimeout = 180, CommandType commandType = CommandType.Text)
        {
            return Query<T>(sql, null, CommandTimeout, commandType);
        }

        protected IEnumerable<T> Query<T>(string sql, IEnumerable<DataParameter> parameters, int CommandTimeout = 600, CommandType commandType = CommandType.Text)
        {
            using (var connection = _dataTransactionContext.GetNewConnection())
            {
                SetSessionContext(connection);

                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = commandType;
                command.CommandTimeout = CommandTimeout;

                if (parameters != null)
                    foreach (var param in parameters)
                        command.Parameters.Add(_dataTransactionContext.GetParatemer(param.Name, param.Value ?? DBNull.Value));

                if (connection.State != ConnectionState.Open) connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    yield return reader.Parse<T>();
            }
        }
        private void SetSessionContext(DbConnection connection)
        {
            var commandIdTalento = connection.CreateCommand();
            commandIdTalento.CommandText = "sys.sp_set_session_context";
            commandIdTalento.CommandType = CommandType.StoredProcedure;
            commandIdTalento.Parameters.Add(_dataTransactionContext.GetParatemer("@key", "IdTalento"));
            commandIdTalento.Parameters.Add(_dataTransactionContext.GetParatemer("@value", SessionContext.Instance.IdUsuario));


            if (connection.State != ConnectionState.Open)   connection.Open();

            commandIdTalento.ExecuteScalar();
        }

    }
}
