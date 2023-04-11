using BuildYourHead.Api.Extensions;

namespace BuildYourHead.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

            builder.AddDbContext();
            builder.Services.AddPersistence();
            builder.Services.AddApplicationServices();

            if (builder.Environment.IsDevelopment())
            {
                builder.Logging.AddConsole();
            }

            var app = builder.Build();

            app.ApplyMigrations();

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
            app.MapControllers();
            app.UseStaticFiles();

            app.Run();
        }
    }
}
