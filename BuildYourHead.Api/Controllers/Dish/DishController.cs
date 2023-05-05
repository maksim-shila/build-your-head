using BuildYourHead.Api.Controllers.Dish.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Dish
{
    [Authorize]
    [ApiController]
    public class DishController : Controller
    {
        [HttpGet]
        [Route("/api/dish/")]
        public IActionResult Get([FromServices] GetDishesRequestHandler handler)
        {
            var result = handler.Handle();
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/dish/")]
        public IActionResult Put(AddDishRequest request, [FromServices] AddDishRequestHandler handler)
        {
            var result = handler.Handle(request);
            return Ok(result);
        }


        [HttpGet]
        [Route("/api/dish/{id}")]
        public IActionResult Get([FromRoute] int id, [FromServices] GetDishRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/dish/{id}")]
        public IActionResult Post([FromRoute] int id, UpdateDishRequest request, [FromServices] UpdateDishRequestHandler handler)
        {
            var result = handler.Handle(id, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/api/dish/{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DeleteDishRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }
    }
}
