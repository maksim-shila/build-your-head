using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Exceptions;
using BuildYourHead.Application.Mappers;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProductService(IProductMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
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
            var entity = new ProductImageDbo { ImagePath = imagePath, ProductId = productId };
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
            _uow.Products.Delete(entity);
            _uow.Save();
        }
    }
}
