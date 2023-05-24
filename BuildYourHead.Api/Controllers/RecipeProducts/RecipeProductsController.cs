using BuildYourHead.Api.Controllers.RecipeProducts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.RecipeProducts
{
    [Authorize]
    [ApiController]
    public class RecipeProductsController : Controller
    {
        [HttpGet]
        [Route("/api/recipe/{id}/products")]
        public IActionResult Get([FromRoute] int id, [FromServices] GetRecipeProductsRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/recipe/{id}/products")]
        public IActionResult Put(
            [FromRoute] int id,
            PutRecipeProductsRequest request,
            [FromServices] PutRecipeProductsRequestHandler handler)
        {
            var result = handler.Handle(id, request);
            return Ok(result);
        }
    }
}
