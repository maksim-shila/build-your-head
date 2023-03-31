using BuildYourHead.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Application.Services.Interfaces
{
    public interface IProductService
    {
        ActionResult Add(ProductDto product);
        ActionResult<ProductDto> Get(int id);
        ActionResult<IList<ProductDto>> GetAll();
    }
}
