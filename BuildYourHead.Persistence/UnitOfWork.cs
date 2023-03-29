using BuildYourHead.Persistence.Repositories.Impl;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence
{
    public class UnitOfWork
    {
        public UnitOfWork(ApplicationContext context)
        {
            Products = new ProductRepository(context);
            Context = context;
        }

        public ApplicationContext Context { get; }

        #region Repositories

        public IProductRepository Products { get; }

        #endregion Repositories

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
