using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;

namespace ICS.DAL.Infrastructure
{
    public interface IDatabaseFactory
    {
        IDatabase CreateDatabase(string connectionString);
    }

    public class DatabaseFactory : IDatabaseFactory
    {
        public IDatabase CreateDatabase(string connString)
        {
            if (string.IsNullOrEmpty(connString.Trim()))
                throw new Exception("Connection string is empty");

            return new Database {ConnectionString = connString };
        }
    }
}
