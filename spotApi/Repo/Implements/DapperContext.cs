using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using spotApi.Repo.Interface;

namespace spotApi.Repo.Implements;
public class DapperContext : IDapperContext
{
    private IDbConnection _db;
    private IDbTransaction _transaction;
    private readonly string _connectionString;

    public DapperContext()
    {
        _connectionString = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=;";
    }

    private IDbConnection GetOpenConnection()
    {
        if (_db == null || _db.State == ConnectionState.Closed)
        {
            _db = new MySqlConnection(_connectionString);
            _db.Open();
        }

        return _db;
    }

    public IDbConnection Db
    {
        get { return GetOpenConnection(); }
    }

    public IDbTransaction Transaction
    {
        get { return _transaction; }
    }

    public void BeginTransaction()
    {
        _transaction = Db.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _transaction?.Commit();
        _transaction = null;
    }

    public void RollbackTransaction()
    {
        _transaction?.Rollback();
        _transaction = null;
    }
}
