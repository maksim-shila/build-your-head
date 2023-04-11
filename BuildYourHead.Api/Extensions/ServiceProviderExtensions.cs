using BuildYourHead.Application.Mappers;
using BuildYourHead.Application.Mappers.Impl;
using BuildYourHead.Application.Services;
using BuildYourHead.Application.Services.Impl;
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

            services.AddTransient<IProductMapper, ProductMapper>();
        }
    }
}
