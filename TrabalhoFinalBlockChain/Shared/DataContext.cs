using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public abstract class DataContext : IDisposable
    {
        protected DbConnection Connection { get; private set; }

        protected DataContext(DbConnection connection)
        {
            Connection = connection;
        }

        public abstract void Open();
        public abstract void Close();
        public abstract void DisposeContext();
        public abstract void ClearPool();

        public abstract DbCommand CreateCommand(string sql, CommandType commandType);
        public abstract DbCommand CreateCommand(string sql, IEnumerable<DataParameter> parameters, CommandType commandType);

        public void Dispose()
        {
            DisposeContext();
        }
    }
}
