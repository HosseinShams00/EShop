using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.SliderAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class IndexModel : PageModel
{
    private readonly ISliderApplication _Application;
    public List<SliderViewModel> ViewModels { get; set; }
    [BindProperty] public bool IsRemoved { get; set; }

    public IndexModel(ISliderApplication sliderApplication)
    {
        _Application = sliderApplication;
        ViewModels = new();
    }

    public void OnGet(bool isRemoved)
    {
        ViewModels = _Application.GetViewModelsWith(isRemoved);
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        _Application.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        _Application.Restore(id);
        return RedirectToPage("./index");
    }
}
