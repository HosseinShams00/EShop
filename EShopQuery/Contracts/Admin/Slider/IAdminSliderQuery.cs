using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace EShopQuery.Contracts.Admin.Slider;

public interface IAdminSliderQuery
{
    EditSlider GetDetail(long id);
    List<SliderQueryModel> GetViewModelsWith(bool IsRemoved);
}
