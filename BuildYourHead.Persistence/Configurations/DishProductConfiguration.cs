using BuildYourHead.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildYourHead.Persistence.Configurations
{
    public class DishProductConfiguration : IEntityTypeConfiguration<DishProductEntity>
    {
        public void Configure(EntityTypeBuilder<DishProductEntity> builder)
        {
            builder.ToTable("DishProduct");

            builder.HasKey(dp => new { dp.ProductId, dp.DishId });

            builder
                .HasOne(dp => dp.Product)
                .WithMany(p => p.DishProducts)
                .HasForeignKey(dp => dp.ProductId);
            builder
                .HasOne(dp => dp.Dish)
                .WithMany(p => p.DishProducts)
                .HasForeignKey(dp => dp.DishId);
        }
    }
}
