using DiscountManager.Domain.ProductCustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManager.Infrastructure.EFCore.Mapping;

public class ProductCustomerDiscountMapping : IEntityTypeConfiguration<ProductCustomerDiscount>
{
    public void Configure(EntityTypeBuilder<ProductCustomerDiscount> builder)
    {
        builder.HasOne(x => x.CustomerDiscount).WithMany(x => x.Products).HasForeignKey(x => x.CustomerDiscountId);
    }
}