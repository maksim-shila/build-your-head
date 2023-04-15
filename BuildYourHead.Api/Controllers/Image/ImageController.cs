using BuildYourHead.Api.Extensions;
using BuildYourHead.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Image
{
    [ApiController]
    [Route("/api/image")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string imageBase64)
        {
            var imagePath = _imageService.Upload(imageBase64);
            return Ok(imagePath);
        }
    }
}
