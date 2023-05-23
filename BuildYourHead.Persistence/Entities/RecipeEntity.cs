namespace BuildYourHead.Persistence.Entities
{
    public class RecipeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
        public List<RecipeProductEntity> RecipeProducts { get; set; } = new List<RecipeProductEntity>();
    }
}
