using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class InventoryOperationMapping : IEntityTypeConfiguration<InventoryOperationQuery>
{
    public void Configure(EntityTypeBuilder<InventoryOperationQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.InventoryId).IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.OperatorId).IsRequired();

        builder.HasOne(x => x.InventoryQuery)
            .WithMany(x => x.InventoryOperationQueries)
            .HasForeignKey(x => x.InventoryId);
    }
}
