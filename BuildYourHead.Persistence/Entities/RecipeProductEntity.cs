namespace BuildYourHead.Persistence.Entities
{
    public class RecipeProductEntity
    {
        public int RecipeId { get; set; }
        public int ProductId { get; set; }

        public RecipeEntity? Recipe { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
