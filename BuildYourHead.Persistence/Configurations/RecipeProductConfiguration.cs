using BuildYourHead.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildYourHead.Persistence.Configurations
{
    public class RecipeProductConfiguration : IEntityTypeConfiguration<RecipeProductEntity>
    {
        public void Configure(EntityTypeBuilder<RecipeProductEntity> builder)
        {
            builder.ToTable("RecipeProduct");

            builder.HasKey(dp => new { dp.ProductId, dp.RecipeId });

            builder
                .HasOne(dp => dp.Product)
                .WithMany(p => p.RecipeProducts)
                .HasForeignKey(dp => dp.ProductId);
            builder
                .HasOne(dp => dp.Recipe)
                .WithMany(p => p.RecipeProducts)
                .HasForeignKey(dp => dp.RecipeId);
        }
    }
}
