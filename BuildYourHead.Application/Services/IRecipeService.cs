using BuildYourHead.Application.Dto;

namespace BuildYourHead.Application.Services
{
    public interface IRecipeService
    {
        IList<RecipeDto> GetAll();
        RecipeDto Get(int id);
        RecipeDto Add(RecipeDto recipe, IList<int>? productIds);
        RecipeDto Update(RecipeDto recipe);
        void Delete(int id);
    }
}
