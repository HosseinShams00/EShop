using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProduct _Command { get; set; }
    private readonly IProductApplication ProductApplication;
    private readonly IAdminProductCategoryQuery _AdminQuery;
    public List<ProductCategoryViewModel> ProductCategroies { get; set; } = new();


    public CreateModel(IProductApplication productApplication,
        IAdminProductCategoryQuery adminQuery)
    {
        ProductApplication = productApplication;
        _AdminQuery = adminQuery;
    }

    public void OnGet()
    {
        _Command = new();
        ProductCategroies = _AdminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            ProductCategroies = _AdminQuery.GetViewModels();
            return Page();
        }

        ProductApplication.Create(_Command);
        return RedirectToPage("./index");
    }

}
