using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain.ReplayCommentQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class ProductReplayCommentMapping : IEntityTypeConfiguration<ProductReplayCommentQuery>
{
    public void Configure(EntityTypeBuilder<ProductReplayCommentQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Message).HasMaxLength(250).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.CommentId).IsRequired();

        builder.HasOne(x => x.ProductCommentQuery)
            .WithMany(x => x.ProductReplayCommentQueries)
            .HasForeignKey(x => x.CommentId);
    }
}