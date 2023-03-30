namespace BuildYourHead.Application.Services.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public double Nutrition { get; set; }
    }
}
