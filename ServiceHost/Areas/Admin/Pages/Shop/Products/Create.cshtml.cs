using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Application.Constracts.ProductCategroyAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProduct createProduct { get; set; }
    private readonly IProductApplication productApplication;
    private readonly IProductCategoryApplication productCategoryApplication;

    public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
    {
        this.productApplication = productApplication;
        this.productCategoryApplication = productCategoryApplication;
    }

    public void OnGet()
    {
        createProduct = new();
        createProduct.ProductCategroyies = productCategoryApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        productApplication.Create(createProduct);
        return RedirectToPage("./index");
    }

}
