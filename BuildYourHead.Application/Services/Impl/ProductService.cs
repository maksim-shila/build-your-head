using BuildYourHead.Application.Core;
using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Exceptions;
using BuildYourHead.Application.Mappers;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Services.Impl
{
    public class ProductService : ServiceBase, IProductService
    {
        private IProductMapper _mapper;

        public ProductService(IProductMapper mapper, IUnitOfWork uow) : base(uow)
        {
            _mapper = mapper;
        }

        public IList<ProductDto> GetAll()
        {
            var entities = Uow.Products.Get();
            return _mapper.ToDtos(entities);
        }

        public ProductDto Add(ProductDto product)
        {
            var entity = _mapper.ToEntity(product);
            Uow.Products.Create(entity);
            Uow.Save();
            return _mapper.ToDto(entity);
        }

        public ProductDto Get(int id)
        {
            var entity = Uow.Products.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Product with id {id} not found.");
            }

            return _mapper.ToDto(entity);
        }

        public void AttachImage(int productId, int imageId, bool primary)
        {
            var entity = new ProductImage { ImageId = imageId, ProductId = productId };
            Uow.ProductImages.Create(entity);
            Uow.Save();
        }

        public void Delete(int id)
        {
            var entity = Uow.Products.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Product with id {id} not found.");
            }
            Uow.Products.Delete(entity);
            Uow.Save();
        }
    }
}
