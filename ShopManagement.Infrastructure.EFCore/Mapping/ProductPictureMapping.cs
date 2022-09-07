using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping;

public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> builder)
    {
        builder.Property(x => x.CreationTime);
        builder.Property(x => x.Path).HasMaxLength(300).IsRequired();
        builder.Property(x => x.PictureAlt).HasMaxLength(100);
        builder.Property(x => x.PictureTitle).HasMaxLength(100);
        builder.Property(x => x.IsRemoved);

        builder.HasOne(x => x.Product).WithMany(q => q.ProductPictures).HasForeignKey(x => x.ProductId);
    }
}