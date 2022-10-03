using CommentManager.Domain.ReplayCommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentManager.Infrastructure.EfCore.Mapping;

public class ProductReplayCommentMapping : IEntityTypeConfiguration<ProductReplayComment>
{
    public void Configure(EntityTypeBuilder<ProductReplayComment> builder)
    {
        builder.Property(x => x.Message).HasMaxLength(250).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.CommentId).IsRequired();

    }
}