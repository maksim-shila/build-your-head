using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Exceptions;
using BuildYourHead.Application.Mappers.Interfaces;
using BuildYourHead.Persistence;

namespace BuildYourHead.Application.Services.Impl
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeMapper _recipeMapper;
        private readonly IProductMapper _productMapper;
        private readonly IUnitOfWork _uow;

        public RecipeService(IRecipeMapper mapper, IProductMapper productMapper, IUnitOfWork uow)
        {
            _recipeMapper = mapper;
            _productMapper = productMapper;
            _uow = uow;
        }

        public IList<RecipeDto> GetAll()
        {
            var entities = _uow.Recipes.Get();
            return _recipeMapper.ToDtos(entities);
        }
        public RecipeDto Get(int id)
        {
            var entity = _uow.Recipes.Get(id);
            if (entity == null)
            {
                throw new NotFoundException($"Recipe with id {id} not found.");
            }

            return _recipeMapper.ToDto(entity);
        }

        public RecipeDto Add(RecipeDto recipe)
        {
            var entity = _recipeMapper.ToEntity(recipe);
            var created = _uow.Recipes.Create(entity);
            _uow.Save();
            return _recipeMapper.ToDto(created);
        }

        public RecipeDto Update(RecipeDto recipe)
        {
            var entity = _recipeMapper.ToEntity(recipe);
            _uow.Recipes.Update(entity);
            _uow.Save();
            return _recipeMapper.ToDto(entity);
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

        public IList<ProductDto> GetProducts(int recipeId)
        {
            var entities = _uow.RecipeProducts.FindByRecipeId(recipeId);
            var productEntities = entities.Select(e => e.Product);
            return _productMapper.ToDtos(productEntities);
        }

        public void AddProducts(int recipeId, IList<int> productsIds)
        {
            var entity = _uow.Recipes.Get(recipeId);
            if (entity == null)
            {
                throw new NotFoundException($"Recipe with id {recipeId} not found.");
            }
            if (productsIds != null && productsIds.Any())
            {
                var products = productsIds.Select(id =>
                {
                    var product = _uow.Products.Get(id);
                    if (product == null)
                    {
                        throw new EntityNotFoundException($"Product with id {id} not exists");
                    }
                    return product;
                });
                entity.Products.AddRange(products);
            }
            _uow.Recipes.Update(entity);
            _uow.Save();
        }
    }
}
