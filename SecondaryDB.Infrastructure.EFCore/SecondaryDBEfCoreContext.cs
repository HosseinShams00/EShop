using Microsoft.EntityFrameworkCore;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore;

public class SecondaryDBEfCoreContext : DbContext
{
    public SecondaryDBEfCoreContext(DbContextOptions<SecondaryDBEfCoreContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }


    public DbSet<ProductCategoryQuery> ProductCategoryQueries { get; set; }
    public DbSet<ProductQuery> ProductQueries { get; set; }
    public DbSet<ProductPictureQuery> ProductPictureQueries { get; set; }
    public DbSet<InventoryQuery> InventoryQueries { get; set; }
    public DbSet<InventoryOperationQuery> InventoryOperationQueries { get; set; }
    public DbSet<CustomerDiscountQuery> CustomerDiscountQueries { get; set; }
    public DbSet<SliderQuery> SliderQueries { get; set; }

}