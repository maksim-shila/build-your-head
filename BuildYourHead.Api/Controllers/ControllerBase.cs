using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers
{
    public class ControllerBase : Controller
    {
        protected T GetRequestHandler<T>() where T : IRequestHandler
        {
            return HttpContext.RequestServices.GetRequiredService<T>();
        }
    }
}
