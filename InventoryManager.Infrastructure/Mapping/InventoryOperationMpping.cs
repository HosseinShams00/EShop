using InventoryManager.Domain.InventoryOperationAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManager.Infrastructure.EFCore.Mapping;

public class InventoryOperationMpping : IEntityTypeConfiguration<InventoryOperation>
{
    public void Configure(EntityTypeBuilder<InventoryOperation> builder)
    {
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.InventoryId).IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.OperatorId).IsRequired();

        builder.HasOne(x => x.Inventory)
            .WithMany(x => x.Operations)
            .HasForeignKey(x => x.InventoryId);
    }
}
