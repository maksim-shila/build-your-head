using BuildYourHead.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildYourHead.Persistence.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
    {
        public void Configure(EntityTypeBuilder<DishEntity> builder)
        {
            builder.ToTable("Dish");

            builder.Property(d => d.Id).HasColumnName("Id");
            builder.Property(d => d.Name).HasColumnName("Name");
            builder.Property(d => d.Description).HasColumnName("Description");

            builder
                .HasMany(d => d.Products)
                .WithMany(p => p.Dishes)
                .UsingEntity<DishProductEntity>();
        }
    }
}
