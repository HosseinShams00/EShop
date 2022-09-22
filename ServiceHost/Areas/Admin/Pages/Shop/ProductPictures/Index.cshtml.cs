using EShopQuery.Contracts.Admin.ProductPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductPictureAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class IndexModel : PageModel
{
    private readonly IProductPictureApplication ProductPictureApplication;
    private readonly IAdminProductPictureQuery _AdminProductPictureQuery;

    public IReadOnlyCollection<ProductPictureQueryModel> ViewModels { get; set; }


    public IndexModel(IProductPictureApplication productPictureApplication, IAdminProductPictureQuery adminroductPictureQuery)
    {
        ProductPictureApplication = productPictureApplication;
        _AdminProductPictureQuery = adminroductPictureQuery;
    }

    public void OnGet()
    {
        ViewModels = _AdminProductPictureQuery.GetViewModels();
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
