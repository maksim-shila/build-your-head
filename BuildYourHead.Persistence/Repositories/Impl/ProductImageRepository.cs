using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class ProductImageRepository : RepositoryBase<ProductImageDbo, int>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationContext context) : base(context) { }
    }
}
