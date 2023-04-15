using BuildYourHead.Api.Controllers.Product.Requests;
using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Product
{
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("/api/product/")]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpPut]
        [Route("/api/product/")]
        public IActionResult Put(ProductDto request)
        {
            var product = _productService.Add(request);
            return Ok(product);
        }

        [HttpPost]
        [Route("/api/product/{id}")]
        public IActionResult Post([FromRoute] int id, [FromBody] ProductDto request)
        {
            request.Id = id;
            var product = _productService.Update(request);
            return Ok(product);
        }

        [HttpGet]
        [Route("/api/product/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var product = _productService.Get(id);
            return Ok(product);
        }

        [HttpDelete]
        [Route("/api/product/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/product/{id}/image")]
        public IActionResult PostImage([FromRoute] int id, [FromBody] PostImageRequest request)
        {
            _productService.AttachImage(id, request.ImagePath, request.Primary);
            return Ok();
        }

        [HttpGet]
        [Route("/api/product/{id}/image/primary")]
        public IActionResult GetPrimaryImage([FromRoute] int id)
        {
            var image = _productService.GetPrimaryImage(id);
            return Ok(image);
        }
    }
}
