using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class CreateModel : PageModel
{
    [BindProperty] public CreateSlider _Command { get; set; }
    private readonly ISliderApplication _Application;

    public CreateModel(ISliderApplication sliderApplication)
    {
        _Application = sliderApplication;
    }

    public void OnGet()
    {
        _Command = new();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _Application.Create(_Command);
        return RedirectToPage("./index");
    }

}
