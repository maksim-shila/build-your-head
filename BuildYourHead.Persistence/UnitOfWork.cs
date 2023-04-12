using BuildYourHead.Persistence.Repositories.Impl;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationContext context)
        {
            Products = new ProductRepository(context);
            ProductImages = new ProductImageRepository(context);
            Context = context;
        }

        protected ApplicationContext Context { get; }

        #region Repositories

        public IProductRepository Products { get; }
        public IProductImageRepository ProductImages { get; }

        #endregion Repositories

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
