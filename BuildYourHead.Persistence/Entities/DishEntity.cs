namespace BuildYourHead.Persistence.Entities
{
    public class DishEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
        public List<DishProductEntity> DishProducts { get; set; } = new List<DishProductEntity>();
    }
}
