using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public abstract class DataTransactionContext : DataContext
    {
        protected DbTransaction Transaction { get; set; }
        public bool InTraction { get; protected set; }
        public string Status => Connection.State.ToString();

        public string ConnectionString { get; set; }

        protected DataTransactionContext(DbConnection connection) : base(connection)
        {
        }

        public abstract DataTransactionContext BeginTransaction();
        public abstract void Commit();
        public abstract void Rollback();

        public abstract DbConnection GetNewConnection();
        public abstract DbParameter GetParatemer(string name, object value);
    }
}
