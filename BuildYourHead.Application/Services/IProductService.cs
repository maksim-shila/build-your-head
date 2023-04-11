using BuildYourHead.Application.Dto;

namespace BuildYourHead.Application.Services
{
    public interface IProductService
    {
        ProductDto Add(ProductDto product);
        ProductDto Get(int id);
        IList<ProductDto> GetAll();
        void AttachImage(int productId, int imageId, bool primary);
        void Delete(int id);
    }
}
