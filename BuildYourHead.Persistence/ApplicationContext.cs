using BuildYourHead.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildYourHead.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<ProductDbo> Products { get; set; }
        public DbSet<ProductImageDbo> ProductImages { get; set; }
    }
}
