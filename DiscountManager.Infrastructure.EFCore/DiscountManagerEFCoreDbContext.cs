using DiscountManager.Domain.CustomerDiscountAgg;
using DiscountManager.Domain.ProductCustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManager.Infrastructure.EFCore;

public class DiscountManagerEFCoreDbContext : DbContext
{
    public DiscountManagerEFCoreDbContext(DbContextOptions<DiscountManagerEFCoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }


    public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
    public DbSet<ProductCustomerDiscount> ProductCustomerDiscounts { get; set; }


}
