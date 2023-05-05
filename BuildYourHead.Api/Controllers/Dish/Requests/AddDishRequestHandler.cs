using BuildYourHead.Api.Exceptions;
using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Services;

namespace BuildYourHead.Api.Controllers.Dish.Requests
{
    public class AddDishRequestHandler : IRequestHandler
    {
        private readonly IDishService _dishService;

        public AddDishRequestHandler(IDishService dishService)
        {
            _dishService = dishService;
        }

        public DishDto Handle(AddDishRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("Dish name should be present");
            }

            var dto = new DishDto
            {
                Name = request.Name,
                Description = request.Description
            };
            return _dishService.Add(dto, request.ProductIds);
        }
    }
}
