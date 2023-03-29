using BuildYourHead.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildYourHead.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
