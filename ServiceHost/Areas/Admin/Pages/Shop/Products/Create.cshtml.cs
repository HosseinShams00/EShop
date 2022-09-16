using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Application.Constracts.ProductCategroyAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProduct _Command { get; set; }
    private readonly IProductApplication ProductApplication;
    private readonly IProductCategoryApplication ProductCategoryApplication;

    public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
    {
        ProductApplication = productApplication;
        ProductCategoryApplication = productCategoryApplication;
    }

    public void OnGet()
    {
        _Command = new();
        _Command.ProductCategroyies = ProductCategoryApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            _Command.ProductCategroyies = ProductCategoryApplication.GetAll();
            return Page();
        }

        ProductApplication.Create(_Command);
        return RedirectToPage("./index");
    }

}
