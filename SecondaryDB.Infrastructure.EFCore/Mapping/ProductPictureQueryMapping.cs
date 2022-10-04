using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain.ProductPictureQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class ProductPictureQueryMapping : IEntityTypeConfiguration<ProductPictureQuery>
{
    public void Configure(EntityTypeBuilder<ProductPictureQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.CreationTime);
        builder.Property(x => x.Path).HasMaxLength(300).IsRequired();
        builder.Property(x => x.PictureAlt).HasMaxLength(100);
        builder.Property(x => x.PictureTitle).HasMaxLength(100);
        builder.Property(x => x.IsRemoved);

        builder.HasOne(x => x.ProductQuery)
            .WithMany(q => q.ProductPictureQueries)
            .HasForeignKey(x => x.ProductId);
    }
}