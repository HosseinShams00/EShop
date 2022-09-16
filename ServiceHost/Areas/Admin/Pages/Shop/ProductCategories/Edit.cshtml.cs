using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class EditModel : PageModel
{
    [BindProperty] public EditProductCategory _Command { get; set; }
    private readonly IProductCategoryApplication ProductCategoryApplication;

    public EditModel(IProductCategoryApplication productCategoryApplication)
    {
        ProductCategoryApplication = productCategoryApplication;
    }

    public void OnGet(long id)
    {
        _Command = ProductCategoryApplication.GetDetail(id);
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        ProductCategoryApplication.Update(_Command);
        return RedirectToPage("./index");
    }
}
