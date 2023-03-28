using BuildYourHead.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = new Product { Id = id };
            return Json(product);
        }

        [HttpPost]
        public IActionResult Post(Product product) 
        {
            return Json(product);
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            return Json(product);
        }

        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
