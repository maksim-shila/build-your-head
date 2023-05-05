using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Controllers.Product.Requests
{
    public class GetProductRequest
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
