using BuildYourHead.Api.Controllers.Recipe.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Recipe
{
    [Authorize]
    [ApiController]
    public class RecipeController : Controller
    {
        [HttpGet]
        [Route("/api/recipe/")]
        public IActionResult Get([FromServices] GetRecipesRequestHandler handler)
        {
            var result = handler.Handle();
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/recipe/")]
        public IActionResult Put(AddRecipeRequest request, [FromServices] PutRecipeRequestHandler handler)
        {
            var result = handler.Handle(request);
            return Ok(result);
        }


        [HttpGet]
        [Route("/api/recipe/{id}")]
        public IActionResult Get([FromRoute] int id, [FromServices] GetRecipeRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/recipe/{id}")]
        public IActionResult Post([FromRoute] int id, UpdateRecipeRequest request, [FromServices] UpdateRecipeRequestHandler handler)
        {
            var result = handler.Handle(id, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/api/recipe/{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DeleteRecipeRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }
    }
}
