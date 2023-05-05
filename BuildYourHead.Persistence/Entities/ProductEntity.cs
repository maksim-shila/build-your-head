namespace BuildYourHead.Persistence.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public double Nutrition { get; set; }

        public List<ProductImageEntity> Images { get; set; } = new List<ProductImageEntity>();
        public List<DishEntity> Dishes { get; set; } = new List<DishEntity>();
        public List<DishProductEntity> DishProducts { get; set; } = new List<DishProductEntity>();
    }
}
