using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductPicture createProduct { get; set; }
    private readonly IProductPictureApplication ProductPictureApplication;
    private readonly IProductApplication ProductApplication;

    public CreateModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
    {
        this.ProductPictureApplication = productPictureApplication;
        this.ProductApplication = productApplication;
    }

    public void OnGet()
    {
        createProduct = new();
        createProduct.Products = ProductApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        ProductPictureApplication.Create(createProduct);
        return RedirectToPage("./index");
    }

}
