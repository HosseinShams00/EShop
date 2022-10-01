using BaseFramework.Repository;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class SliderQueryRepository : BaseQueryRepository<long, SliderQuery>, ISliderQueryRepository
{
    public SliderQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}
