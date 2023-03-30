using BuildYourHead.Application.Services.Dto;

namespace BuildYourHead.Application.Services.Interfaces
{
    public interface IProductService
    {
        void Add(ProductDto product);
        ProductDto? Get(int id);

    }
}
