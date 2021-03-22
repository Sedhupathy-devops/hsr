using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ICS.DAL.Infrastructure
{
    public interface IDatabaseManager
    {
        IDbConnection CreateDbConnection();
        IDbConnection CreateDbConnection(string connectionString);
        IDatabase Database { get; set; }
        public string ConnectionString { get; set; }
    }

    public class DatabaseManager : IDatabaseManager
    {
        private IDatabaseFactory _databaseFactory;
        public string ConnectionString { get; set; }
        private IDatabase _database;

        public DatabaseManager(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public IDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = _databaseFactory.CreateDatabase(ConnectionString);
                }
                return _database;
            }
            set
            {
                _database = value;
            }
        }

        public IDbConnection CreateDbConnection()
        {
            return CreateDbConnection(ConnectionString);
        }

        public IDbConnection CreateDbConnection(string connectionString)
        {
            return new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        }
    }
}
