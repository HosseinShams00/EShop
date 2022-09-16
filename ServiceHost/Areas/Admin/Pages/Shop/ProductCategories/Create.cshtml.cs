using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductCategory _Command { get; set; }
    private readonly IProductCategoryApplication productCategoryApplication;

    public CreateModel(IProductCategoryApplication productCategoryApplication)
    {
        this.productCategoryApplication = productCategoryApplication;
    }

    public void OnGet()
    {
        _Command = new();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        productCategoryApplication.Create(_Command);
        return RedirectToPage("./index");
    }
}
