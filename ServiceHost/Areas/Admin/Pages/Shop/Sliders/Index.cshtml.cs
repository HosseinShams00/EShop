using EShopQuery.Contracts.Admin.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.SliderAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class IndexModel : PageModel
{
    private readonly ISliderApplication _application;
    private readonly IAdminSliderQuery _adminSliderQuery;

    public IReadOnlyCollection<SliderQueryModel> ViewModels { get; set; }
    [BindProperty] public bool IsRemoved { get; set; }

    public IndexModel(ISliderApplication sliderApplication, IAdminSliderQuery adminSliderQuery)
    {
        _application = sliderApplication;
        _adminSliderQuery = adminSliderQuery;
    }

    public void OnGet(bool isRemoved)
    {
        ViewModels = _adminSliderQuery.GetViewModelsWith(isRemoved);
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        _application.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        _application.Restore(id);
        return RedirectToPage("./index");
    }
}
