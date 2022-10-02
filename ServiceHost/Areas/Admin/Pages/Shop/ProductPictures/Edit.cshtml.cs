using EShopQuery.Contracts.Admin.Product;
using EShopQuery.Contracts.Admin.ProductPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductPictureAgg;
using ShopManagement.Application.Contract.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class EditModel : PageModel
{
    [BindProperty] public EditProductPicture Command { get; set; }
    private readonly IProductPictureApplication _productApplication;
    private readonly IAdminProductQuery _adminQuery;
    private readonly IAdminProductPictureQuery _adminProductPictureQuery;

    public IReadOnlyCollection<ProductQueryModel> Products { get; set; }

    public EditModel(IProductPictureApplication productPictureApplication,
        IAdminProductQuery adminQuery,
        IAdminProductPictureQuery adminProductPictureQuery)
    {
        _productApplication = productPictureApplication;
        _adminQuery = adminQuery;
        _adminProductPictureQuery = adminProductPictureQuery;
    }

    public void OnGet(long id)
    {
        Command = _adminProductPictureQuery.GetDetail(id);
        Products = _adminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            Products = _adminQuery.GetViewModels();
            return Page();
        }

        _productApplication.Update(Command);
        return RedirectToPage("./index");
    }
}
