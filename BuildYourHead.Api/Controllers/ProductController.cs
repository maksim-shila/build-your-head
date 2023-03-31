using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IList<ProductDto>> Get()
        {
            Console.WriteLine("GET ALL PRODUCTS");
            return _productService.GetAll();
        }

        [HttpGet]
        [Route("/api/product/{id:int:min(0)}")]
        public ActionResult<ProductDto> Get([FromRoute] int id)
        {
            return _productService.Get(id);
        }

        [HttpPut]
        public ActionResult Put(ProductDto product)
        {
            return _productService.Add(product);
        }
    }
}
