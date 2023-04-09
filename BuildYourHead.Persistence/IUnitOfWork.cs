using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IImageRepository Images { get; }
        IProductImageRepository ProductImages { get; }

        void Save();
    }
}
