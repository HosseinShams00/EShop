using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategroyAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class IndexModel : PageModel
{
    private readonly IProductCategoryApplication _productCategoryApplication;
    private readonly IAdminProductCategoryQuery _adminQuery;

    public ProductCategorySearchModel SearchModel { get; set; }
    public IReadOnlyCollection<ProductCategoryQueryModel> ViewModels { get; set; }


    public IndexModel(IProductCategoryApplication productCategoryApplication, IAdminProductCategoryQuery adminQuery)
    {
        _productCategoryApplication = productCategoryApplication;
        SearchModel = new();
        _adminQuery = adminQuery;
    }

    public void OnGet(ProductCategorySearchModel searchModel)
    {
        ViewModels = _adminQuery.Search(searchModel);
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        _productCategoryApplication.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        _productCategoryApplication.Restore(id);
        return RedirectToPage("./index");
    }
}
