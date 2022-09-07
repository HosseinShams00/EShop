using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
        builder.Property(x => x.ShortDecription).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Picture).HasMaxLength(1000);
        builder.Property(x => x.PictureAlt).HasMaxLength(255);
        builder.Property(x => x.PictureTitle).HasMaxLength(500);
        builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
        builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

        builder.HasOne(x => x.ProductCategory).WithMany(q => q.Products).HasForeignKey(z => z.ProductCategoryId);
    }
}