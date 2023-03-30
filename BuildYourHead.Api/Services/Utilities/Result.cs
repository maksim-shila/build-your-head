using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Services.Utilities
{
    public static class Result
    {
        public static ActionResult<T> Json<T>(T obj) where T : class
        {
            return new JsonResult(obj);
        }

        public static ActionResult NotFound()
        {
            return new NotFoundResult();
        }

        public static ActionResult Ok()
        {
            return new OkResult();
        }
    }
}
