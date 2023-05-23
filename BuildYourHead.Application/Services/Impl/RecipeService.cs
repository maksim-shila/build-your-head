using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Exceptions;
using BuildYourHead.Application.Mappers.Interfaces;
using BuildYourHead.Persistence;

namespace BuildYourHead.Application.Services.Impl
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeMapper _mapper;
        private readonly IUnitOfWork _uow;

        public RecipeService(IRecipeMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public IList<RecipeDto> GetAll()
        {
            var entities = _uow.Recipes.Get();
            return _mapper.ToDtos(entities);
        }
        public RecipeDto Get(int id)
        {
            var entity = _uow.Recipes.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Recipe with id {id} not found.");
            }

            return _mapper.ToDto(entity);
        }

        public RecipeDto Add(RecipeDto recipe, IList<int>? productIds)
        {
            var entity = _mapper.ToEntity(recipe);
            var created = _uow.Recipes.Create(entity);
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

        public RecipeDto Update(RecipeDto recipe)
        {
            var entity = _mapper.ToEntity(recipe);
            _uow.Recipes.Update(entity);
            _uow.Save();
            return _mapper.ToDto(entity);
        }

        public void Delete(int id)
        {
            var entity = _uow.Recipes.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Recipe with id {id} not found.");
            }
            _uow.Recipes.Delete(entity);
            _uow.Save();
        }
    }
}
