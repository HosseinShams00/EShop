using EShopQuery.Contracts.DbContract;
using EShopQuery.EfCore.Repository.BaseRepository;

namespace EShopQuery.EfCore.Repository;

public class ProductCategoryQueryRepository : BaseQueryRepository<long, ProductCategoryQuery>
{
    public ProductCategoryQueryRepository(EShopQueryEfCoreContext context) : base(context)
    {
    }
}
