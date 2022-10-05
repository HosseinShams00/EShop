using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain.ProductCommentQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class ProductCommentMapping : IEntityTypeConfiguration<ProductCommentQuery>
{
    public void Configure(EntityTypeBuilder<ProductCommentQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Message).HasMaxLength(250).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

        builder.HasOne(x => x.ProductQuery)
            .WithMany(x => x.ProductCommentQueries)
            .HasForeignKey(x => x.ProductQueryId);

        builder.HasMany(x => x.ProductReplayCommentQueries)
            .WithOne(x => x.ProductCommentQuery)
            .HasForeignKey(x => x.CommentId);
    }
}