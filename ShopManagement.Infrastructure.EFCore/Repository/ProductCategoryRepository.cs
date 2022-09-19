using BaseFramwork.Repository;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductCategoryRepository : BaseRepository<long, ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(ShopManagerEFCoreDbContext context) : base(context)
    {
    }
}
