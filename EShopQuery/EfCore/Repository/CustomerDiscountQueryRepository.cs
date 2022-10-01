using EShopQuery.Contracts.DbContract;
using EShopQuery.EfCore.Repository.BaseRepository;

namespace EShopQuery.EfCore.Repository;

public class CustomerDiscountQueryRepository : BaseQueryRepository<long, CustomerDiscountQuery>
{
    public CustomerDiscountQueryRepository(EShopQueryEfCoreContext context) : base(context)
    {
    }
}
