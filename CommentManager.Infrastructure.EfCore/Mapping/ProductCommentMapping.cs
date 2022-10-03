using CommentManager.Domain.ProductCommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentManager.Infrastructure.EfCore.Mapping;

public class ProductCommentMapping : IEntityTypeConfiguration<ProductComment>
{
    public void Configure(EntityTypeBuilder<ProductComment> builder)
    {
        builder.Property(x => x.Message).HasMaxLength(250).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

    }
}