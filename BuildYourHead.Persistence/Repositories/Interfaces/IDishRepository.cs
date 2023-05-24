using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Persistence.Repositories.Interfaces
{
    public interface IRecipeRepository : IRepository<RecipeEntity, int>
    {
        RecipeEntity? GetWithProducts(int recipeId);
    }
}
