using AutoMapper;
using BuildYourHead.Application.Services.Dto;
using BuildYourHead.Persistence.Entities;

namespace BuildYourHead.Application
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
