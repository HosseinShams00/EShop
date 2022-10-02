using EShopQuery.Contracts.Admin.ProductPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductPictureAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class IndexModel : PageModel
{
    private readonly IProductPictureApplication _productPictureApplication;
    private readonly IAdminProductPictureQuery _adminProductPictureQuery;

    public IReadOnlyCollection<ProductPictureQueryModel> ViewModels { get; set; }


    public IndexModel(IProductPictureApplication productPictureApplication, IAdminProductPictureQuery adminProductPictureQuery)
    {
        _productPictureApplication = productPictureApplication;
        _adminProductPictureQuery = adminProductPictureQuery;
    }

    public void OnGet()
    {
        ViewModels = _adminProductPictureQuery.GetViewModels();
    }

    public RedirectToPageResult OnGetRemove(long id)
    {
        _productPictureApplication.Delete(id);
        return RedirectToPage("./index");
    }

    public RedirectToPageResult OnGetRestore(long id)
    {
        _productPictureApplication.Restore(id);
        return RedirectToPage("./index");
    }
}
