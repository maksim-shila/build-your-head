using AutoMapper;
using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Api.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
