using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICS.DAL.Infrastructure
{
    public interface IDatabase
    {
        string ConnectionString { get; set; }

        IDbConnection CreateConnection();
        IDbCommand Command();
        IDbConnection OpenCOnnection();
    }

    public class Database : IDatabase
    {
        public string ConnectionString { get; set; }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public IDbCommand Command()
        {
            return new MySqlCommand();
        }

        public IDbConnection OpenCOnnection()
        {
            MySqlConnection connection = (MySqlConnection)CreateConnection();
            connection.Open();
            return connection;
        }
    }
}
