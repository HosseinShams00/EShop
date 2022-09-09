using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class CreateModel : PageModel
{
    [BindProperty] public CreateSlider createSlider { get; set; }
    private readonly ISliderApplication SliderApplication;

    public CreateModel(ISliderApplication sliderApplication)
    {
        this.SliderApplication = sliderApplication;
    }

    public void OnGet()
    {
        createSlider = new();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        SliderApplication.Create(createSlider);
        return RedirectToPage("./index");
    }

}
