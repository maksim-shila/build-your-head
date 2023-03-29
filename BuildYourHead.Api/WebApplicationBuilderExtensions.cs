using BuildYourHead.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildYourHead.Api
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connectionString, new MySqlServerVersion("8.0.32")));
        }
    }
}
