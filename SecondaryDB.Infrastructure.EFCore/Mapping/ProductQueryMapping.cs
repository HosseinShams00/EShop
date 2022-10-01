using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class ProductQueryMapping : IEntityTypeConfiguration<ProductQuery>
{
    public void Configure(EntityTypeBuilder<ProductQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
        builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Picture).HasMaxLength(1000);
        builder.Property(x => x.PictureAlt).HasMaxLength(255);
        builder.Property(x => x.PictureTitle).HasMaxLength(500);
        builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
        builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

        builder.HasOne(x => x.ProductCategoryQuery)
            .WithMany(q => q.Products)
            .HasForeignKey(z => z.ProductCategoryId);

        builder.HasMany(x => x.ProductPictureQueries)
            .WithOne(q => q.ProductQuery)
            .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.InventoryQuery)
            .WithOne(x => x.ProductQuery);

        builder.HasOne(x => x.CustomerDiscountQuery)
            .WithMany(x => x.ProductQueries)
            .HasForeignKey(x => x.CustomerDiscountId);

    }
}
