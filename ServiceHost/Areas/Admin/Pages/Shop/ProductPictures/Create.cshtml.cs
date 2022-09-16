using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductPicture _Command { get; set; }
    private readonly IProductPictureApplication ProductPictureApplication;
    private readonly IProductApplication ProductApplication;

    public CreateModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
    {
        ProductPictureApplication = productPictureApplication;
        ProductApplication = productApplication;
    }

    public void OnGet()
    {
        _Command = new();
        _Command.Products = ProductApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            _Command.Products = ProductApplication.GetAll();
            return Page();
        }

        ProductPictureApplication.Create(_Command);
        return RedirectToPage("./index");
    }

}
