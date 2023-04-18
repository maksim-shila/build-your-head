using BuildYourHead.Api.Extensions;

namespace BuildYourHead.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddCustomAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

            builder.Services.AddDbContext(configuration);
            builder.Services.AddOptions(configuration);
            builder.Services.AddPersistence();
            builder.Services.AddApplicationServices();

            if (builder.Environment.IsDevelopment())
            {
                builder.Logging.AddConsole();
            }

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.ApplyMigrations();
            app.UseCustomMiddlewares();
            app.MapControllers();

            app.Run();
        }
    }
}
