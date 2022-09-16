using DiscountManager.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManager.Infrastructure.EFCore.Mapping;

public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
{
    public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(300);
        builder.Property(x => x.DiscountPercent).IsRequired();

        builder.HasMany(x => x.Products).WithOne(x => x.CustomerDiscount).HasForeignKey(x => x.CustomerDiscountId);

    }
}
