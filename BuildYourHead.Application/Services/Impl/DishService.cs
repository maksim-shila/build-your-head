using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Exceptions;
using BuildYourHead.Application.Mappers.Interfaces;
using BuildYourHead.Persistence;

namespace BuildYourHead.Application.Services.Impl
{
    public class DishService : IDishService
    {
        private readonly IDishMapper _mapper;
        private readonly IUnitOfWork _uow;

        public DishService(IDishMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public IList<DishDto> GetAll()
        {
            var entities = _uow.Dishes.Get();
            return _mapper.ToDtos(entities);
        }
        public DishDto Get(int id)
        {
            var entity = _uow.Dishes.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Dish with id {id} not found.");
            }

            return _mapper.ToDto(entity);
        }

        public DishDto Add(DishDto dish, IList<int>? productIds)
        {
            var entity = _mapper.ToEntity(dish);
            var created = _uow.Dishes.Create(entity);
            if (productIds != null && productIds.Any())
            {
                var products = productIds.Select(id =>
                {
                    var product = _uow.Products.Get(id);
                    if (product == null)
                    {
                        throw new EntityNotFoundException($"Product with id {id} not exists");
                    }
                    return product;
                });
                created.Products.AddRange(products);
            }
            _uow.Save();
            return _mapper.ToDto(created);
        }

        public DishDto Update(DishDto dish)
        {
            var entity = _mapper.ToEntity(dish);
            _uow.Dishes.Update(entity);
            _uow.Save();
            return _mapper.ToDto(entity);
        }

        public void Delete(int id)
        {
            var entity = _uow.Dishes.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Dish with id {id} not found.");
            }
            _uow.Dishes.Delete(entity);
            _uow.Save();
        }
    }
}
