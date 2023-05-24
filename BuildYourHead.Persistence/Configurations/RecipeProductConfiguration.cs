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

            builder.HasKey(rp => new { rp.ProductId, rp.RecipeId });

            builder
                .HasOne(rp => rp.Product)
                .WithMany(p => p.RecipeProducts)
                .HasForeignKey(rp => rp.ProductId);
            builder
                .HasOne(rp => rp.Recipe)
                .WithMany(p => p.RecipeProducts)
                .HasForeignKey(rp => rp.RecipeId);

            builder.Navigation(rp => rp.Product).AutoInclude();
            builder.Navigation(rp => rp.Recipe).AutoInclude();
        }
    }
}
