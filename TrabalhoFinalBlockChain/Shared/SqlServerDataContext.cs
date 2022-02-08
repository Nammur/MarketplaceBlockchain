using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public class SqlServerDataContext : DataTransactionContext
    {
        SqlServerDataContext(string connectionString) : base(new SqlConnection(connectionString))
        {
            ConnectionString = connectionString;
        }

        public static DataTransactionContext Create(string connectionString)
        {
            return new SqlServerDataContext(connectionString);
        }

        public override void Open() => TryOpenConnection();
        public override void Close() => Dispose();
        public override void ClearPool() => SqlConnection.ClearPool(Connection as SqlConnection);

        public override DbConnection GetNewConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override DbParameter GetParatemer(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public override DataTransactionContext BeginTransaction()
        {
            if (InTraction && Transaction != null)
                new InvalidOperationException("Já existe uma Transação aberta");

            TryOpenConnection();
            TryBeginTransaction();
            return this;
        }

        public override void Commit()
        {
            Transaction.Commit();
            TryCloseConnection();
            TryDisposeTransaction();
        }

        public override void Rollback()
        {
            Transaction.Rollback();
            TryCloseConnection();
            TryDisposeTransaction();
        }

        public override void DisposeContext()
        {
            TryDisposeTransaction();
            TryCloseConnection();
        }

        public override DbCommand CreateCommand(string sql, CommandType commandType)
        {
            DbCommand command;

            if (InTraction)
                command = new SqlCommand(sql, Connection as SqlConnection, Transaction as SqlTransaction);
            else
                command = new SqlCommand(sql, Connection as SqlConnection);

            command.CommandType = commandType;

            return command;
        }

        public override DbCommand CreateCommand(string sql, IEnumerable<DataParameter> parameters, CommandType commandType)
        {
            DbCommand command = CreateCommand(sql, commandType);
            command.Parameters.AddRange(GetSqlParameters(parameters).ToArray());
            return command;
        }

        private void TryCloseConnection()
        {
            if (Connection?.State == ConnectionState.Open)
                Connection?.Close();
        }

        private void TryOpenConnection()
        {
            if (Connection?.State == ConnectionState.Closed)
                Connection?.Open();
        }

        private void TryBeginTransaction()
        {
            if (Transaction == null)
                Transaction = Connection.BeginTransaction();
            InTraction = true;
        }

        private void TryDisposeTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
                InTraction = false;
            }
        }

        private IEnumerable<SqlParameter> GetSqlParameters(IEnumerable<DataParameter> parameters)
        {
            foreach (var @param in parameters)
            {
                var paramResult = new SqlParameter(@param.Name, @param.Value ?? DBNull.Value);
                paramResult.DbType = @param.DataType;

                if (@param.Size != default(int))
                    paramResult.Size = @param.Size;

                yield return paramResult;
            }
        }

    }
}
