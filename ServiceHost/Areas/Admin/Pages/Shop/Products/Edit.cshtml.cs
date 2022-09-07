using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.ProductCategoryAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class EditModel : PageModel
{
    [BindProperty] public EditProduct editProduct { get; set; }
    private readonly IProductApplication productApplication;
    private readonly IProductCategoryApplication productCategoryApplication;


    public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
    {
        this.productApplication = productApplication;
        this.productCategoryApplication = productCategoryApplication;
    }

    public void OnGet(long id)
    {
        editProduct = productApplication.GetDetail(id);
        editProduct.ProductCategroyies = productCategoryApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        productApplication.Update(editProduct);
        return RedirectToPage("./index");
    }
}
