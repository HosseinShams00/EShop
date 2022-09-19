using EShopQuery.Contracts.Admin.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class IndexModel : PageModel
{
    private readonly IProductApplication _Application;
    private readonly IAdminProductQuery _AdminQuery;

    public ProductSearchModel SearchModel { get; set; }
    public List<ProductViewModel> ViewModels { get; set; }

    public IndexModel(IProductApplication productApplication, IAdminProductQuery adminQuery)
    {
        _Application = productApplication;
        SearchModel = new();
        ViewModels = new();
        _AdminQuery = adminQuery;
    }

    public void OnGet(ProductSearchModel searchModel)
    {
        ViewModels = _AdminQuery.Search(searchModel);
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
