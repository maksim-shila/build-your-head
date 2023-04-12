using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }

        void Save();
    }
}
