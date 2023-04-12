using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class ProductRepository : RepositoryBase<ProductDbo, int>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context) { }
    }
}
