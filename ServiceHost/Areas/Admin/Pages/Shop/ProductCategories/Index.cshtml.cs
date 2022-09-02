using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroy;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class IndexModel : PageModel
{
    private readonly IProductCategoryApplication ProductCategoryApplication;
    public ProductCategorySearchModel SearchModel { get; set; }
    public List<ProductCategoryViewModel> ViewModel { get; set; }


    public IndexModel(IProductCategoryApplication productCategoryApplication)
    {
        ProductCategoryApplication = productCategoryApplication;
        SearchModel = new();
        ViewModel = new();
    }

    public void OnGet(ProductCategorySearchModel searchModel)
    {
        ViewModel = ProductCategoryApplication.Search(searchModel);
        //SearchModel = searchModel;
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
