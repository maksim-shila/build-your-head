namespace BuildYourHead.Api.Controllers.Product.Requests
{
    public class PostImageRequest
    {
        public string ImagePath { get; set; } = null!;
        public bool Primary { get; set; }
    }
}
