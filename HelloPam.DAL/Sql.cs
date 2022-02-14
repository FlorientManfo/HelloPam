using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace HelloPam.DAL
{
    public class Sql
    {
        private readonly string connectionString;
        private readonly string providerName;
        private readonly DbProviderFactory factory;

        public Sql(string connectionString, string providerName)
        {
            this.connectionString = connectionString;
            this.providerName = providerName;
            factory = DbProviderFactories.GetFactory(providerName);
        }

        public Sql(string connectionStringName) :
            this(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString,
                ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName)
        {
        }

        /// <summary>
        /// Retourne un objet connexion ouvert
        /// </summary>
        /// <returns>DdConnection</returns>
        private DbConnection GetConnexion()
        {
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }

        private DbCommand GetCommand(string query, IEnumerable<Parameter> parameters,
            bool isStoredProcedure)
        {
            var command = factory.CreateCommand();
            command.CommandText = query;
            if (isStoredProcedure)
                command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var p = factory.CreateParameter();
                    p.ParameterName = parameter.Name;
                    p.DbType = parameter.Type;
                    p.Value = parameter.Value;
                    p.Direction = parameter.Direction;
                    command.Parameters.Add(p);
                }
            }
            return command;
        }

        public Dictionary<string, object> Execute(string query, IEnumerable<Parameter> parameters,
            bool isStoredProcedure = false)
        {
            Dictionary<string, object> outputs = new Dictionary<string, object>();
            using (var connection = GetConnexion())
            {
                using (var command = GetCommand(query, parameters, isStoredProcedure))
                {
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    foreach (DbParameter p in command.Parameters)
                    {
                        if (p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Output)
                        {
                            outputs.Add(p.ParameterName, p.Value);
                        }
                    }
                }
            }
            return outputs;
        }

        public DbDataReader Read(string query, IEnumerable<Parameter> parameters,
            bool isStoredProcedure = false)
        {
            var connection = GetConnexion();
            var command = GetCommand(query, parameters, isStoredProcedure);
            command.Connection = connection;
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public IEnumerable<T> Read<T>(string query, IEnumerable<Parameter> parameters,
          Func<DbDataReader, T> callBack, bool isStoredProcedure = false)
        {
            List<T> datas = new List<T>();
            using (var connection = GetConnexion())
            {
                using (var command = GetCommand(query, parameters, isStoredProcedure))
                {
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datas.Add(callBack.Invoke(reader));
                        }
                        reader.Close();
                    }
                }
            }
            return datas;
        }


        public class Parameter
        {
            public string Name { get; set; }
            public DbType Type { get; set; }
            public object Value { get; set; }
            public ParameterDirection Direction { get; set; }

            public Parameter(string name, DbType type, object value)
            {
                Name = name;
                Type = type;
                Value = value;
                Direction = ParameterDirection.Input;
            }
            public Parameter(string name, DbType type, object value,
                ParameterDirection direction) : this(name, type, value)
            {
                Direction = direction;
            }
        }
    }
}
