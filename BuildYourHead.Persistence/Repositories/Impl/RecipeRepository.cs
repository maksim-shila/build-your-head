using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class RecipeRepository : RepositoryBase<RecipeEntity, int>, IRecipeRepository
    {
        public RecipeRepository(ApplicationContext context) : base(context) { }

        public RecipeEntity? GetWithProducts(int recipeId)
        {
            return DbSet
                .Where(recipe => recipe.Id == recipeId)
                .Include(recipe => recipe.Products)
                .FirstOrDefault();
        }
    }
}
