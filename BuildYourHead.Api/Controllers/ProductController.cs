using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        public ProductController(UnitOfWork uow)
        {
            Uow = uow;
        }

        public UnitOfWork Uow { get; }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = Uow.Products.Get(id);
            return Json(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            Uow.Products.Update(product);
            Uow.Save();
            return Json(product);
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            Uow.Products.Create(product);
            Uow.Save();
            return Json(product);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var product = Uow.Products.Get(id);
            Uow.Products.Delete(product);
            Uow.Save();
        }
    }
}
