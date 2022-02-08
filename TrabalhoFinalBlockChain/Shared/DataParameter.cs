using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public class DataParameter
    {
        public string Name { get; private set; }
        public object Value = null;
        public DbType DataType { get; private set; }
        public int Size { get; private set; }

        DataParameter(string name, object value, DbType dbType = DbType.String, int size = default(int))
        {
            Name = name;
            Value = value;
            DataType = dbType;
            Size = size;
        }

        public static DataParameter Create(string name, object value) =>
            new(name, value);

        public static DataParameter Create(string name, object value, DbType dbType) =>
            new (name, value, dbType);

        public static DataParameter Create(string name, object value, DbType dbType, int size) =>
            new (name, value, dbType, size);
    }
}
