using BuildYourHead.Api.Controllers.Product.Requests;
using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Application.Services.Interfaces;
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
            Console.WriteLine("GET ALL PRODUCTS");
            return _productService.GetAll();
        }

        [HttpPut]

        [Route("/api/product/")]
        public ActionResult<ProductDto> Put(ProductDto product)
        {
            return _productService.Add(product);
        }
        [HttpGet]
        [Route("/api/product/{id}")]
        public ActionResult<ProductDto> Get([FromRoute] int id)
        {
            return _productService.Get(id);
        }

        [HttpDelete]
        [Route("/api/product/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            return _productService.Delete(id);
        }

        [HttpPost]
        [Route("/api/product/{id}/image")]
        public ActionResult PostImage([FromRoute] int id, [FromBody] PostImageRequest request)
        {
            return _productService.AttachImage(id, request.ImageId, request.Primary);
        }
    }
}
