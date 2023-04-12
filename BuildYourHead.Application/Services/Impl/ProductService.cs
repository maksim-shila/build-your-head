using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Exceptions;
using BuildYourHead.Application.Mappers;
using BuildYourHead.Infrastructure.ImageStorage;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductMapper _mapper;
        private readonly IImageStorage _imageStorage;
        private readonly IUnitOfWork _uow;

        public ProductService(IProductMapper mapper, IImageStorage imageStorage, IUnitOfWork uow)
        {
            _mapper = mapper;
            _imageStorage = imageStorage;
            _uow = uow;
        }

        public IList<ProductDto> GetAll()
        {
            var entities = _uow.Products.Get();
            return _mapper.ToDtos(entities);
        }

        public ProductDto Add(ProductDto product)
        {
            var entity = _mapper.ToEntity(product);
            _uow.Products.Create(entity);
            _uow.Save();
            return _mapper.ToDto(entity);
        }

        public ProductDto Update(ProductDto product)
        {
            var entity = _mapper.ToEntity(product);
            _uow.Products.Update(entity);
            _uow.Save();
            return _mapper.ToDto(entity);
        }

        public ProductDto Get(int id)
        {
            var entity = _uow.Products.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Product with id {id} not found.");
            }

            return _mapper.ToDto(entity);
        }

        public void AttachImage(int productId, string imagePath, bool primary)
        {
            var entity = new ProductImageDbo { ImagePath = imagePath, ProductId = productId, IsPrimary = primary };
            if (primary)
            {
                _uow.ProductImages.ResetPrimary(productId);
            }
            _uow.ProductImages.Create(entity);
            _uow.Save();
        }

        public void Delete(int id)
        {
            var entity = _uow.Products.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Product with id {id} not found.");
            }
            var imagesPaths = _uow.ProductImages.GetPaths(id);
            _uow.Products.Delete(entity);
            _uow.Save();

            _imageStorage.Delete(imagesPaths);
        }

        public byte[]? GetPrimaryImage(int id)
        {
            var productImageEntity = _uow.ProductImages.GetPrimaryImage(id);
            if (productImageEntity == null)
            {
                return null;
            }
            var path = productImageEntity.ImagePath;
            var image = _imageStorage.Get(path);
            if (image == null)
            {
                throw new NotFoundException($"Image '{path}' not found");
            }
            return image.Content;
        }
    }
}
