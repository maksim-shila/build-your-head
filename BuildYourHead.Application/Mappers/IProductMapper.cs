using BuildYourHead.Application.Dto;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Mappers
{
    public interface IProductMapper
    {
        ProductDbo ToEntity(ProductDto dto);
        ProductDto ToDto(ProductDbo entity);
        IList<ProductDbo> ToEntities(IEnumerable<ProductDto> dtos);
        IList<ProductDto> ToDtos(IEnumerable<ProductDbo> entities);
    }
}
