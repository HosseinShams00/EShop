using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ShopManagement.Domain.SliderAgg;

public interface ISliderRepository : IBaseRepository<long, Slider>
{
    EditSlider? GetDetails(long id);
    List<SliderViewModel> GetViewModels();
}
