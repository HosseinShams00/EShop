using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class IndexModel : PageModel
{
    private readonly IProductApplication _Application;
    public ProductSearchModel SearchModel { get; set; }
    public List<ProductViewModel> ViewModels { get; set; }


    public IndexModel(IProductApplication productApplication)
    {
        _Application = productApplication;
        SearchModel = new();
        ViewModels = new();
    }

    public void OnGet(ProductSearchModel searchModel)
    {
        ViewModels = _Application.Search(searchModel);
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
