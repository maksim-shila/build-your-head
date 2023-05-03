using BuildYourHead.Api.Exceptions;
using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Services;

namespace BuildYourHead.Api.Controllers.Dish.Requests
{
    public class GetDishRequestHandler : IRequestHandler
    {
        private IDishService _dishService;

        public GetDishRequestHandler(IDishService dishService)
        {
            _dishService = dishService;
        }

        public DishDto Handle(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Dish id should be greater than zero");
            }

            return _dishService.Get(id);
        }
    }
}
