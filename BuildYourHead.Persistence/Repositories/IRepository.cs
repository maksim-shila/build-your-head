namespace BuildYourHead.Persistence.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        TEntity? Get(TKey id);
        IEnumerable<TEntity> Get();
        IQueryable<TEntity> GetAsQueryable();

        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
