using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public static class DataReaderBinder
    {
        public static T Parse<T>(this DbDataReader reader)
        {
            var instance = Activator.CreateInstance<T>();

            foreach (var property in instance.GetType().GetRuntimeProperties())
            {
                try
                {
                    if (!ColumnExists(reader, property.Name))
                        continue;

                    if (IsDbNullValue(reader, property.Name))
                        continue;

                    property.SetValue(instance, reader[property.Name]);
                }
                catch (Exception ex)
                {
                    throw new Exception("Campo: " + property.Name + " ERROR: " + ex.Message);
                }
            }

            return instance;
        }

        private static bool ColumnExists(DbDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).ToLowerInvariant() == columnName.ToLowerInvariant())
                    return true;
            }

            return false;
        }

        private static bool IsDbNullValue(DbDataReader reader, string field)
        {
            return reader[field] == null || reader[field] == DBNull.Value;
        }
    }
}
