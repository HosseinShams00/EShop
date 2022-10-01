using EShopQuery.Contracts.DbContract;
using EShopQuery.EfCore.Repository.BaseRepository;

namespace EShopQuery.EfCore.Repository;

public class ProductQueryRepository : BaseQueryRepository<long, ProductQuery>
{
    public ProductQueryRepository(EShopQueryEfCoreContext context) : base(context)
    {
    }
}
