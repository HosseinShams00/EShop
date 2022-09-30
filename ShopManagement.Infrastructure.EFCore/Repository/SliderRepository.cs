using BaseFramework.Repository;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class SliderRepository : BaseRepository<long, Slider>, ISliderRepository
{
    public SliderRepository(ShopManagerEFCoreDbContext context) : base(context)
    {
    }
}
