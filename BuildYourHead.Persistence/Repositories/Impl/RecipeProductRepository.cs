using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class RecipeProductRepository : RepositoryBase<RecipeProductEntity, int[]>, IRecipeProductRepository
    {
        public RecipeProductRepository(ApplicationContext context) : base(context) { }

        public IList<RecipeProductEntity> FindByRecipeId(int recipeId)
        {
            return DbSet.Where(rp => rp.RecipeId == recipeId).ToList();
        }
    }
}
