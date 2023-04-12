using BuildYourHead.Application.Dto;
using BuildYourHead.Persistence.Entities;
using System.Collections.Immutable;

namespace BuildYourHead.Application.Mappers.Impl
{
    public class ProductMapper : IProductMapper
    {
        public ProductDbo ToEntity(ProductDto dto)
        {
            return new ProductDbo
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Proteins = dto.Proteins,
                Fats = dto.Fats,
                Carbohydrates = dto.Carbohydrates,
                Nutrition = dto.Nutrition
            };
        }

        public ProductDto ToDto(ProductDbo entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Proteins = entity.Proteins,
                Fats = entity.Fats,
                Carbohydrates = entity.Carbohydrates,
                Nutrition = entity.Nutrition
            };
        }

        public IList<ProductDto> ToDtos(IEnumerable<ProductDbo> entities)
        {
            return entities.Select(ToDto).ToImmutableList();
        }

        public IList<ProductDbo> ToEntities(IEnumerable<ProductDto> dtos)
        {
            return dtos.Select(ToEntity).ToImmutableList();
        }
    }
}
