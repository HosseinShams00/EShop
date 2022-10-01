using EShopQuery.Contracts.DbContract;
using EShopQuery.EfCore.Repository.BaseRepository;

namespace EShopQuery.EfCore.Repository;

public class SliderQueryRepository : BaseQueryRepository<long, SliderQuery>
{
    public SliderQueryRepository(EShopQueryEfCoreContext context) : base(context)
    {
    }
}
