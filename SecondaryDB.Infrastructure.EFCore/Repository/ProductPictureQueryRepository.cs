using BaseFramework.Repository;
using SecondaryDB.Domain.ProductPictureQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Repository;
public class ProductPictureQueryRepository : BaseQueryRepository<long, ProductPictureQuery>, IProductPictureQueryRepository
{
    public ProductPictureQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}