using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ICS.DAL.Infrastructure
{

    public interface IDapperManager
    {
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null);

        T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);

        int Execute(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);
    }
    public class DapperManager : IDapperManager
    {
        private IDatabaseManager _databaseManager;
        public DapperManager(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public IDatabaseManager DatabaseManager {
            get { return _databaseManager; }
            //set { _databaseManager = value; }
        }

        public IEnumerable<T> Query<T>(string sql, object param=null, IDbTransaction transaction=null, bool buffered=true,
            int? commandTimeout=null, CommandType? commandType=null)
        {
            using (var dbConnection = _databaseManager.CreateDbConnection())
            {
                return dbConnection.Query<T>(sql, param,transaction, buffered, commandTimeout, commandType);
            }
        }

        public T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = _databaseManager.CreateDbConnection())
            {
                return dbConnection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, 
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = _databaseManager.CreateDbConnection())
            {
                return dbConnection.Execute(sql, param, transaction, commandTimeout, commandType);
            }
        }
    }
}
