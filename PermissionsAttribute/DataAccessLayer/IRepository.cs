namespace PermissionsAttribute.DataAccessLayer
{
    interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        TEntity GetById(int id);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
