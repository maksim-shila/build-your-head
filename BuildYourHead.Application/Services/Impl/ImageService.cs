using BuildYourHead.Application.Core;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Services.Impl
{
    public class ImageService : ServiceBase, IImageService
    {
        public ImageService(IUnitOfWork uow) : base(uow)
        {
        }

        public int Upload(byte[] image)
        {
            var entity = new Image { Content = image };
            Uow.Images.Create(entity);
            Uow.Save();
            return entity.Id;
        }
    }
}
