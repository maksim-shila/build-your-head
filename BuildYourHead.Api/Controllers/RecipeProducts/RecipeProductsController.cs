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
        [Route("/api/recipe/{id}/product")]
        public IActionResult Get([FromRoute] int id, [FromServices] GetRecipeProductsRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/recipe/{id}/product")]
        public IActionResult Put(
            [FromRoute] int id,
            PutRecipeProductsRequest request,
            [FromServices] PutRecipeProductsRequestHandler handler)
        {
            var result = handler.Handle(id, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/api/recipe/{recipeId}/product/{productId}")]
        public IActionResult Delete(
            [FromRoute] int recipeId,
            [FromRoute] int productId,
            [FromServices] DeleteRecipeProductsRequestHandler handler)
        {
            var result = handler.Handle(recipeId, productId);
            return Ok(result);
        }
    }
}
