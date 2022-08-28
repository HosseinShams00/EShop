using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.Mapping;

namespace ShopManagement.Infrastructure.EFCore;

public class EFCoreDbContext : DbContext
{
	public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var assembly = typeof(ProductCategoryMapping).Assembly;

		modelBuilder.ApplyConfigurationsFromAssembly(assembly);
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<ProductCategory> ProductCategories { get; set; }


}