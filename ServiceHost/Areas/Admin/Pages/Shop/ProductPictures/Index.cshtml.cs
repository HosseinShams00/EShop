using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductPictureAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class IndexModel : PageModel
{
    private readonly IProductPictureApplication ProductPictureApplication;
    public List<ProductPictureViewModel> ViewModels { get; set; }


    public IndexModel(IProductPictureApplication productPictureApplication)
    {
        ProductPictureApplication = productPictureApplication;
        ViewModels = new();
    }

    public void OnGet()
    {
        ViewModels = ProductPictureApplication.GetAll();
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        ProductPictureApplication.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        ProductPictureApplication.Restore(id);
        return RedirectToPage("./index");
    }
}
