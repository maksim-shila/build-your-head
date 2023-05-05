using BuildYourHead.Api.Exceptions;
using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Services;

namespace BuildYourHead.Api.Controllers.Dish.Requests
{
    public class UpdateDishRequestHandler : IRequestHandler
    {
        private IDishService _dishService;

        public UpdateDishRequestHandler(IDishService dishService)
        {
            _dishService = dishService;
        }

        internal DishDto Handle(int id, UpdateDishRequest request)
        {
            if (id <= 0)
            {
                throw new ValidationException("Dish id should be greater than zero");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("Dish name should be present");
            }
            var dto = new DishDto
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
            };

            return _dishService.Update(dto);
        }
    }
}
