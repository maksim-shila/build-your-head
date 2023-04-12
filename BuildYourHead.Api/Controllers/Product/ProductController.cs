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
        public ActionResult<IList<ProductDto>> Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpPut]
        [Route("/api/product/")]
        public ActionResult<ProductDto> Put(ProductDto request)
        {
            var product = _productService.Add(request);
            return Ok(product);
        }

        [HttpGet]
        [Route("/api/product/{id}")]
        public ActionResult<ProductDto> Get([FromRoute] int id)
        {
            var product = _productService.Get(id);
            return Ok(product);
        }

        [HttpDelete]
        [Route("/api/product/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/product/{id}/image")]
        public ActionResult PostImage([FromRoute] int id, [FromBody] PostImageRequest request)
        {
            _productService.AttachImage(id, request.ImagePath, request.Primary);
            return Ok();
        }
    }
}
