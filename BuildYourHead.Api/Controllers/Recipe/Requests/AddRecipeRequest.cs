namespace BuildYourHead.Api.Controllers.Recipe.Requests
{
    public class AddRecipeRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public IList<int>? ProductIds { get; set; }
    }
}
