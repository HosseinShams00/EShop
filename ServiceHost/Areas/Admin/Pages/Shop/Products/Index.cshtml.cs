using EShopQuery.Contracts.Admin.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class IndexModel : PageModel
{
    private readonly IProductApplication _application;
    private readonly IAdminProductQuery _adminQuery;

    public ProductSearchModel SearchModel { get; set; }
    public IReadOnlyCollection<ProductQueryModel> ViewModels { get; set; }

    public IndexModel(IProductApplication productApplication, IAdminProductQuery adminQuery)
    {
        _application = productApplication;
        _adminQuery = adminQuery;
        SearchModel = new();
    }

    public void OnGet(ProductSearchModel searchModel)
    {
        ViewModels = _adminQuery.Search(searchModel);
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
