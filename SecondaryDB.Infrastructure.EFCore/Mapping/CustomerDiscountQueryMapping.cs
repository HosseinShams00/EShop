using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain.CustomerDiscountQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class CustomerDiscountQueryMapping : IEntityTypeConfiguration<CustomerDiscountQuery>
{
    public void Configure(EntityTypeBuilder<CustomerDiscountQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(300);
        builder.Property(x => x.DiscountPercent).IsRequired();

        builder.HasMany(x => x.ProductQueries)
            .WithOne(x => x.CustomerDiscountQuery)
            .HasForeignKey(x => x.CustomerDiscountId);

    }
}
