using BuildYourHead.Api.Services;
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
        }

        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
