namespace BuildYourHead.Persistence.Entities
{
    public class DishProductEntity
    {
        public int DishId { get; set; }
        public int ProductId { get; set; }

        public DishEntity? Dish { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
