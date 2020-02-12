namespace DataAccess.Core
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        TEntity GetById(int id);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
