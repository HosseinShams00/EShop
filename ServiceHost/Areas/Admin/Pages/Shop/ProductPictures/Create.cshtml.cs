using EShopQuery.Contracts.Admin.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductPicture _Command { get; set; }
    private readonly IProductPictureApplication ProductPictureApplication;
    private readonly IAdminProductQuery _AdminQuery;

    public IReadOnlyCollection<ProductQueryModel> Products { get; set; }

    public CreateModel(IProductPictureApplication productPictureApplication, IAdminProductQuery adminQuery)
    {
        ProductPictureApplication = productPictureApplication;
        _AdminQuery = adminQuery;
    }

    public void OnGet()
    {
        _Command = new();
        Products = _AdminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            Products = _AdminQuery.GetViewModels();
            return Page();
        }

        ProductPictureApplication.Create(_Command);
        return RedirectToPage("./index");
    }

}
