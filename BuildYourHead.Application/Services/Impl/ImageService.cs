using BuildYourHead.Infrastructure.ImageStorage;

namespace BuildYourHead.Application.Services.Impl
{
    public class ImageService : IImageService
    {
        private readonly IImageStorage _storage;

        public ImageService(IImageStorage storage)
        {
            _storage = storage;
        }

        public string Upload(byte[] image)
        {
            return _storage.Upload(image).Path;
        }
    }
}
