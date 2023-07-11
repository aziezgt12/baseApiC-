using System.Data;

namespace spotApi.Repo.Interface
{
    public interface IDapperContext
    {
        IDbConnection Db { get; }
        IDbTransaction Transaction { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
