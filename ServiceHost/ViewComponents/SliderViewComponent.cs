using EShopQuery.Contracts.User.Slider;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class SliderViewComponent : ViewComponent
{
    private readonly IUserSliderQuery _userSliderQuery;

    public SliderViewComponent(IUserSliderQuery userSliderQuery)
    {
        _userSliderQuery = userSliderQuery;
    }

    public IViewComponentResult Invoke()
    {
        var sliders = _userSliderQuery.GetViewModels();
        return View(sliders);
    }
}
