using AutoMapper;
using BuildYourHead.Api.Services.Utilities;
using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Application.Services.Interfaces;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Application.Services.Impl
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public ActionResult Add(ProductDto product)
        {
            var entity = Mapper.Map<Product>(product);
            Uow.Products.Create(entity);
            Uow.Save();
            return Result.Ok();
        }

        public ActionResult<ProductDto> Get(int id)
        {
            var entity = Uow.Products.Get(id);
            if (entity == null)
            {
                return Result.NotFound();
            }

            var dto = Mapper.Map<ProductDto>(entity);
            return Result.Json(dto);
        }
    }
}
