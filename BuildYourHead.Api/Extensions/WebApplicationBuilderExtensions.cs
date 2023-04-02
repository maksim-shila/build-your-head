using BuildYourHead.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BuildYourHead.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new ArgumentException("Connection string is not specified in configuration");
            }
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion("8.0.32"));
            });
        }
    }
}
