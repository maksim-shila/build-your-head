using BuildYourHead.Application.Services;
using BuildYourHead.Application.Services.Impl;

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
            _dishService.Delete(id);
            return $"Dish {id} successfully removed";
        }
    }
}
