using AutoMapper;
using BuildYourHead.Api.Services.Utilities;
using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Application.Services.Interfaces;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace BuildYourHead.Application.Services.Impl
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public ActionResult<IList<ProductDto>> GetAll()
        {
            var entities = Uow.Products.Get();
            var dtos = entities.Select(Mapper.Map<ProductDto>).ToImmutableList();
            return Result.Json((IList<ProductDto>)dtos);
        }

        public ActionResult<ProductDto> Add(ProductDto product)
        {
            var entity = Mapper.Map<Product>(product);
            Uow.Products.Create(entity);
            Uow.Save();
            var dto = Mapper.Map<ProductDto>(entity);
            return Result.Json(dto);
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

        public ActionResult AttachImage(int productId, int imageId, bool primary)
        {
            var entity = new ProductImage { ImageId = imageId, ProductId = productId };
            Uow.ProductImages.Create(entity);
            Uow.Save();
            return Result.Ok();
        }

        public ActionResult Delete(int id)
        {
            var entity = Uow.Products.Get(id);
            if (entity == null)
            {
                return Result.NotFound();
            }
            Uow.Products.Delete(entity);
            Uow.Save();
            return Result.Ok();
        }
    }
}
