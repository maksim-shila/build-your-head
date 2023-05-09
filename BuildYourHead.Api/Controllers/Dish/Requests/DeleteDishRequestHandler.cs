using BuildYourHead.Api.Exceptions;
using BuildYourHead.Application.Services;

namespace BuildYourHead.Api.Controllers.Dish.Requests
{
    public class DeleteDishRequestHandler : IRequestHandler
    {
        private readonly IDishService _dishService;

        public DeleteDishRequestHandler(IDishService dishService)
        {
            _dishService = dishService;
        }

        public string Handle(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Dish id should be greater than zero");
            }

            _dishService.Delete(id);
            return $"Dish {id} successfully removed";
        }
    }
}
