using EShopQuery.Contracts.DbContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShopQuery.EfCore.Mapping;

public class InventoryQueryMapping : IEntityTypeConfiguration<InventoryQuery>
{
    public void Configure(EntityTypeBuilder<InventoryQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasMany(x => x.InventoryOperationQueries)
            .WithOne(x => x.InventoryQuery)
            .HasForeignKey(x => x.InventoryId);

        builder.HasOne(x => x.ProductQuery)
            .WithOne(x => x.InventoryQuery)
            .HasForeignKey<InventoryQuery>(x => x.ProductId);
    }
}
