using Microsoft.EntityFrameworkCore;
using SecondaryDB.Domain.CustomerDiscountQueryAgg;
using SecondaryDB.Domain.InventoryQueryAgg;
using SecondaryDB.Domain.ProductCategoryQueryAgg;
using SecondaryDB.Domain.ProductCommentQueryAgg;
using SecondaryDB.Domain.ProductPictureQueryAgg;
using SecondaryDB.Domain.ProductQueryAgg;
using SecondaryDB.Domain.ReplayCommentQueryAgg;
using SecondaryDB.Domain.SliderQueryAgg;

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
    public DbSet<ProductCommentQuery> ProductCommentQueries { get; set; }
    public DbSet<ProductReplayCommentQuery> ProductReplayCommentQueries { get; set; }


}