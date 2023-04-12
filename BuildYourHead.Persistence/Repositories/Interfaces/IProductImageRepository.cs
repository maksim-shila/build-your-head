using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Persistence.Repositories.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImageDbo, int>
    {
        IList<string> GetPaths(int productId);
        ProductImageDbo? GetPrimaryImage(int productId);
        void ResetPrimary(int productId);
    }
}
