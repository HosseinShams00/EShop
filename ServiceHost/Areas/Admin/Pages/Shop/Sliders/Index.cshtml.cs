using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.SliderAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class IndexModel : PageModel
{
    private readonly ISliderApplication SliderApplication;
    public List<SliderViewModel> ViewModel { get; set; }
    public bool IsRemoved { get; set; }

    public IndexModel(ISliderApplication sliderApplication)
    {
        SliderApplication = sliderApplication;
        ViewModel = new();
    }

    public void OnGet()
    {
        ViewModel = SliderApplication.GetViewModelsWith(IsRemoved);
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        SliderApplication.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        SliderApplication.Restore(id);
        return RedirectToPage("./index");
    }
}