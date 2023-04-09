using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class ImageRepository : RepositoryBase<Image, int>, IImageRepository
    {
        public ImageRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
