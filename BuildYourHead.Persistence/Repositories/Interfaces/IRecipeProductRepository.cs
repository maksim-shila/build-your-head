using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Persistence.Repositories.Interfaces
{
    public interface IRecipeProductRepository : IRepository<RecipeProductEntity, int[]>
    {
        IList<RecipeProductEntity> FindByRecipeId(int recipeId);
    }
}
