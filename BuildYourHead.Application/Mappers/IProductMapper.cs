using BuildYourHead.Application.Dto;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Mappers
{
    public interface IProductMapper
    {
        Product ToEntity(ProductDto dto);
        ProductDto ToDto(Product entity);
        IList<Product> ToEntities(IEnumerable<ProductDto> dtos);
        IList<ProductDto> ToDtos(IEnumerable<Product> entities);
    }
}
