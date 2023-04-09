using BuildYourHead.Api.Controllers.Product.Requests;
using BuildYourHead.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Application.Services.Interfaces
{
    public interface IProductService
    {
        ActionResult<ProductDto> Add(ProductDto product);
        ActionResult<ProductDto> Get(int id);
        ActionResult<IList<ProductDto>> GetAll();
        ActionResult AttachImage(int productId, int imageId, bool primary);
        ActionResult Delete(int id);
    }
}
