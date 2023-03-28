using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers
{
    [ApiController]
    [Route("/api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Hello world!";
        }
    }
}
