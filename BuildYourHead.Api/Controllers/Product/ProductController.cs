using BuildYourHead.Api.Controllers.Product.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Product
{
    [Authorize]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("/api/product/")]
        public IActionResult Get([FromServices] GetProductsRequestHandler handler)
        {
            var result = handler.Handle();
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/product/")]
        public IActionResult Put(AddProductRequest request, [FromServices] AddProductRequestHandler handler)
        {
            var result = handler.Handle(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/product/{id}")]
        public IActionResult Get([FromRoute] int id, [FromServices] GetProductRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/product/{id}")]
        public IActionResult Post([FromRoute] int id, UpdateProductRequest request, [FromServices] UpdateProductRequestHandler handler)
        {
            var result = handler.Handle(id, request);
            return Ok(result);
        }        

        [HttpDelete]
        [Route("/api/product/{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] DeleteProductRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/product/{id}/image")]
        public IActionResult PostImage([FromRoute] int id, PostProductImageRequest request, [FromServices] PostProductImageRequestHandler handler)
        {
            var result = handler.Handle(id, request);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/product/{id}/image/primary")]
        public IActionResult GetPrimaryImage([FromRoute] int id, [FromServices] GetPrimaryImageRequestHandler handler)
        {
            var result = handler.Handle(id);
            return Ok(result);
        }
    }
}
