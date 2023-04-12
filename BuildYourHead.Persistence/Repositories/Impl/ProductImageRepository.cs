using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;
using System.Collections.Immutable;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class ProductImageRepository : RepositoryBase<ProductImageDbo, int>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationContext context) : base(context) { }

        public IList<string> GetPaths(int productId)
        {
            return DbSet
                .Where(x => x.ProductId == productId)
                .Select(x => x.ImagePath)
                .ToImmutableList();
        }
    }
}
