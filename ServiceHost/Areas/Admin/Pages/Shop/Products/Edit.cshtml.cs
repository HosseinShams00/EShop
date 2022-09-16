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
    private readonly IProductCategoryApplication ProductCategoryApplication;


    public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
    {
        ProductApplication = productApplication;
        ProductCategoryApplication = productCategoryApplication;
    }

    public void OnGet(long id)
    {
        _Command = ProductApplication.GetDetail(id);
        _Command.ProductCategroyies = ProductCategoryApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            _Command.ProductCategroyies = ProductCategoryApplication.GetAll();
            return Page();
        }
        ProductApplication.Update(_Command);
        return RedirectToPage("./index");
    }
}
