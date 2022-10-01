using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class ProductCategoryQueryMapping : IEntityTypeConfiguration<ProductCategoryQuery>
{
    public void Configure(EntityTypeBuilder<ProductCategoryQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Picture).HasMaxLength(1000);
        builder.Property(x => x.PictureAlt).HasMaxLength(255);
        builder.Property(x => x.PictureTitle).HasMaxLength(500);
        builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
        builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

        builder.HasMany(x => x.Products)
            .WithOne(q => q.ProductCategoryQuery)
            .HasForeignKey(z => z.ProductCategoryId);
    }
}
