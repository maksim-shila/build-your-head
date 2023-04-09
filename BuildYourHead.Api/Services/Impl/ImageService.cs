using AutoMapper;
using BuildYourHead.Api.Extensions;
using BuildYourHead.Api.Services.Interfaces;
using BuildYourHead.Application.Services;
using BuildYourHead.Persistence;
using BuildYourHead.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourHead.Api.Services.Impl
{
    public class ImageService : ServiceBase, IImageService
    {
        public ImageService(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public ActionResult<int> Upload(IFormFile image)
        {
            var bytes = image.ToByteArray();
            var entity = new Image { Content = bytes };
            Uow.Images.Create(entity);
            Uow.Save();
            return entity.Id;
        }
    }
}
