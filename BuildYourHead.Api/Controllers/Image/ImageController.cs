using BuildYourHead.Api.Controllers.Image.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Image
{
    [ApiController]
    public class ImageController : Controller
    {
        [HttpPost]
        [Route("/api/image")]
        public IActionResult Post(PostImageRequest request, [FromServices] PostImageRequestsHandler handler)
        {
            var result = handler.Handle(request);
            return Ok(result);
        }
    }
}
