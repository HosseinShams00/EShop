using EShopQuery.Contracts.Admin.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductPicture Command { get; set; }
    private readonly IProductPictureApplication _productPictureApplication;
    private readonly IAdminProductQuery _adminQuery;

    public IReadOnlyCollection<ProductQueryModel> Products { get; set; }

    public CreateModel(IProductPictureApplication productPictureApplication,
        IAdminProductQuery adminQuery)
    {
        _productPictureApplication = productPictureApplication;
        _adminQuery = adminQuery;
    }

    public void OnGet()
    {
        Command = new();
        Products = _adminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            Products = _adminQuery.GetViewModels();
            return Page();
        }

        _productPictureApplication.Create(Command);
        return RedirectToPage("./index");
    }

}
