﻿using System.Data.SqlClient;

namespace Persistence.Factories
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection SqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
