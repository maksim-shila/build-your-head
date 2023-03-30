using BuildYourHead.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace BuildYourHead.Api
{
    public static class ServiceProviderExtensions
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<UnitOfWork>();
        } 
    }
}
