namespace BuildYourHead.Persistence.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> Get();
        IQueryable<TEntity> GetAsQueryable();

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
