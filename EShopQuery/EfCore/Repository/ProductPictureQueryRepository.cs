using EShopQuery.Contracts.DbContract;
using EShopQuery.EfCore.Repository.BaseRepository;

namespace EShopQuery.EfCore.Repository;
public class ProductPictureQueryRepository : BaseQueryRepository<long, ProductPictureQuery>
{
    public ProductPictureQueryRepository(EShopQueryEfCoreContext context) : base(context)
    {
    }
}