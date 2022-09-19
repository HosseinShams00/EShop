using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace EShopQuery.Contracts.Admin.Slider;

public interface IAdminSliderQuery
{
    EditSlider GetDetail(long id);
    List<SliderViewModel> GetViewModelsWith(bool IsRemoved);
}
