using InventoryManager.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManager.Infrastructure.EFCore.Mapping;

public class InventoryMpping : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.Property(x => x.ProductId).IsRequired();

        builder.HasMany(x => x.Operations)
            .WithOne(x => x.Inventory)
            .HasForeignKey(x => x.InventoryId);
    }
}
