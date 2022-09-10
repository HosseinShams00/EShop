using EShopQuery.Contracts.Slider;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class SliderViewComponent : ViewComponent
{
    private readonly ISliderQuery SliderQuery;

    public SliderViewComponent(ISliderQuery sliderQuery)
    {
        SliderQuery = sliderQuery;
    }

    public IViewComponentResult Invoke()
    {
        var sliders = SliderQuery.GetViewModels();
        return View(sliders);
    }
}
