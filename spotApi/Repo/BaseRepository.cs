//using System.Data;
//using Dapper;

//namespace spotApi.Repo
//{
//    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
//    {
//        protected readonly IDbConnection _connection;

//        public BaseRepository(IDbConnection connection)
//        {
//            _connection = ConnectionFactory.CreateConnection();
//        }

//        public TEntity GetById(int id)
//        {
//            return _connection.Get<TEntity>(id);
//        }

//        public IEnumerable<TEntity> GetAll()
//        {
//            return _connection.GetList<TEntity>();
//        }

//        public void Add(TEntity entity)
//        {
//            _connection.Insert(entity);
//        }

//        public void Update(TEntity entity)
//        {
//            _connection.Update(entity);
//        }

//        public void Delete(TEntity entity)
//        {
//            _connection.Delete(entity);
//        }
//    }

//}



