using BuildYourHead.Application.Dto;

namespace BuildYourHead.Application.Services
{
    public interface IDishService
    {
        IList<DishDto> GetAll();
        DishDto Get(int id);
        DishDto Add(DishDto dish, IList<int>? productIds);
        DishDto Update(DishDto dish);
        void Delete(int id);
    }
}
