using EShopQuery.Contracts.DbContract;
using EShopQuery.EfCore.Repository.BaseRepository;

namespace EShopQuery.EfCore.Repository;

public class InventoryQueryRepository : BaseQueryRepository<long, InventoryQuery>
{
    public InventoryQueryRepository(EShopQueryEfCoreContext context) : base(context)
    {
    }
}
