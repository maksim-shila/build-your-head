using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Mappers.Interfaces;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application.Mappers.Impl
{
    public class DishMapper : IDishMapper
    {
        public DishDto ToDto(DishEntity entity)
        {
            return new DishDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        public DishEntity ToEntity(DishDto dto)
        {
            return new DishEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }
    }
}
