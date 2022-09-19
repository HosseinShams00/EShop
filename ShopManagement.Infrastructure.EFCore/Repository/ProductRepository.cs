using BaseFramwork.Repository;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductRepository : BaseRepository<long, Product>, IProductRepository
{
    public ProductRepository(ShopManagerEFCoreDbContext context) : base(context)
    {
    }
}
