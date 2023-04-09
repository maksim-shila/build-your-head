using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Services.Interfaces
{
    public interface IImageService
    {
        ActionResult<int> Upload(IFormFile image);
    }
}
