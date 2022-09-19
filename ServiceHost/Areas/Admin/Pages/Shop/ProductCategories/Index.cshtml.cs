using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroyAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class IndexModel : PageModel
{
    private readonly IProductCategoryApplication ProductCategoryApplication;
    private readonly IAdminProductCategoryQuery _AdminQuery;

    public ProductCategorySearchModel SearchModel { get; set; }
    public List<ProductCategoryViewModel> ViewModels { get; set; }


    public IndexModel(IProductCategoryApplication productCategoryApplication, IAdminProductCategoryQuery adminQuery)
    {
        ProductCategoryApplication = productCategoryApplication;
        SearchModel = new();
        ViewModels = new();
        _AdminQuery = adminQuery;
    }

    public void OnGet(ProductCategorySearchModel searchModel)
    {
        ViewModels = _AdminQuery.Search(searchModel);
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        ProductCategoryApplication.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        ProductCategoryApplication.Restore(id);
        return RedirectToPage("./index");
    }
}
