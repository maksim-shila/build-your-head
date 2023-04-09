using Microsoft.EntityFrameworkCore;

namespace BuildYourHead.Persistence.Repositories
{
    internal class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        public RepositoryBase(ApplicationContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        public TEntity? Get(TKey id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return DbSet.ToList(); ;
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return DbSet.AsQueryable();
        }

        public TEntity Create(TEntity entity)
        {
            var entry = DbSet.Add(entity);
            return entry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entry = DbSet.Update(entity);
            return entry.Entity;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
