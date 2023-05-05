using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Services;

namespace BuildYourHead.Api.Controllers.Dish.Requests
{
    public class GetDishesRequestHandler : IRequestHandler
    {
        private readonly IDishService _dishService;

        public GetDishesRequestHandler(IDishService dishService)
        {
            _dishService = dishService;
        }

        public IList<DishDto> Handle()
        {
            return _dishService.GetAll();
        }
    }
}
