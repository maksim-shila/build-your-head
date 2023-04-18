using BuildYourHead.Api.Options;
using BuildYourHead.Application.Mappers;
using BuildYourHead.Application.Mappers.Impl;
using BuildYourHead.Application.Services;
using BuildYourHead.Application.Services.Impl;
using BuildYourHead.Infrastructure.ImageStorage;
using BuildYourHead.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

            services.AddTransient<IImageStorage, DbImageStorage>();
            services.AddTransient<IImageService, ImageService>();

            services.AddTransient<IProductMapper, ProductMapper>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new ArgumentException("Connection string is not specified in configuration");
            }
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion("8.0.32"));
            });
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ImageStorageOptions>(configuration.GetSection("ImageStorage"));
        }

        public static void AddCustomAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }
    }
}
