using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class IndexModel : PageModel
{
    private readonly IProductApplication ProductApplication;
    public ProductSearchModel SearchModel { get; set; }
    public List<ProductViewModel> ViewModel { get; set; }


    public IndexModel(IProductApplication productApplication)
    {
        ProductApplication = productApplication;
        SearchModel = new();
        ViewModel = new();
    }

    public void OnGet(ProductSearchModel searchModel)
    {
        ViewModel = ProductApplication.Search(searchModel);
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        ProductApplication.Delete(id);
        return RedirectToPage("./index");

    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        ProductApplication.Restore(id);
        return RedirectToPage("./index");

    }
}
