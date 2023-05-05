namespace BuildYourHead.Api.Controllers.Dish.Requests
{
    public class AddDishRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public IList<int>? ProductIds { get; set; }
    }
}
