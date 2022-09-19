using BaseFramwork.Repository;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductPictureRepository : BaseRepository<long, ProductPicture>, IProductPictureRepository
{
    public ProductPictureRepository(ShopManagerEFCoreDbContext context) : base(context)
    {
    }
}