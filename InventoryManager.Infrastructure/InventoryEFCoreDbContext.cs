using InventoryManager.Domain.InventoryAgg;
using InventoryManager.Domain.InventoryOperationAgg;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.EFCore;

public class InventoryEFCoreDbContext : DbContext
{
    public InventoryEFCoreDbContext(DbContextOptions<InventoryEFCoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryOperation> InventoryOperations { get; set; }

}