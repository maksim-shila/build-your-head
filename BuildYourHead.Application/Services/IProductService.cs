using BuildYourHead.Application.Dto;

namespace BuildYourHead.Application.Services
{
    public interface IProductService
    {
        ProductDto Get(int id);
        ProductDto Add(ProductDto product);
        ProductDto Update(ProductDto request);
        IList<ProductDto> GetAll();
        void Delete(int id);
        void AttachImage(int productId, string imagePath, bool primary);
        byte[]? GetPrimaryImage(int id);
    }
}
