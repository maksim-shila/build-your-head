﻿using BuildYourHead.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BuildYourHead.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            db.Database.Migrate();
        }
    }
}
