using EShopQuery.Contracts.Admin.Product;
using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class EditModel : PageModel
{
    [BindProperty] public EditProduct _Command { get; set; }
    private readonly IProductApplication ProductApplication;
    private readonly IAdminProductCategoryQuery _AdminQuery;
    private readonly IAdminProductQuery _AdminProductQuery;

    public List<ProductCategoryViewModel> ProductCategroies { get; set; } = new();

    public EditModel(IProductApplication productApplication, IAdminProductCategoryQuery adminQuery, IAdminProductQuery adminProductQuery)
    {
        ProductApplication = productApplication;
        _AdminQuery = adminQuery;
        _AdminProductQuery = adminProductQuery;
    }

    public void OnGet(long id)
    {
        try
        {
            _Command = _AdminProductQuery.GetDetail(id);
            ProductCategroies = _AdminQuery.GetViewModels();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            ProductCategroies = _AdminQuery.GetViewModels();
            return Page();
        }
        ProductApplication.Update(_Command);
        return RedirectToPage("./index");
    }
}
