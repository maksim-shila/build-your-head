using AutoMapper;
using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Application.Services.Interfaces;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Services.Impl
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public void Add(ProductDto product)
        {
            var entity = Mapper.Map<Product>(product);
            Uow.Products.Create(entity);
            Uow.Save();
        }
    }
}
