using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.ProductCategoryAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class EditModel : PageModel
{
    [BindProperty] public EditProduct _Command { get; set; }
    private readonly IProductApplication ProductApplication;
    private readonly IAdminProductCategoryQuery _AdminQuery;


    public EditModel(IProductApplication productApplication, IAdminProductCategoryQuery adminQuery)
    {
        ProductApplication = productApplication;
        _AdminQuery = adminQuery;
    }

    public void OnGet(long id)
    {
        _Command = ProductApplication.GetDetail(id);
        _Command.ProductCategroyies = _AdminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            _Command.ProductCategroyies = _AdminQuery.GetViewModels();
            return Page();
        }
        ProductApplication.Update(_Command);
        return RedirectToPage("./index");
    }
}
