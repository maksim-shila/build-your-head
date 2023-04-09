using BuildYourHead.Api.Services;
using BuildYourHead.Api.Services.Impl;
using BuildYourHead.Api.Services.Interfaces;
using BuildYourHead.Application.Services.Impl;
using BuildYourHead.Application.Services.Interfaces;
using BuildYourHead.Persistence;

namespace BuildYourHead.Api.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IImageService, ImageService>();
        }

        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
