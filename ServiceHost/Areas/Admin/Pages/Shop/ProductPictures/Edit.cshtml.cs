using EShopQuery.Contracts.Admin.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class EditModel : PageModel
{
    [BindProperty] public EditProductPicture _Command { get; set; }
    private readonly IProductPictureApplication ProductApplication;
    private readonly IAdminProductQuery _AdminQuery;


    public EditModel(IProductPictureApplication productPictureApplication, IAdminProductQuery adminQuery)
    {
        ProductApplication = productPictureApplication;
        _AdminQuery = adminQuery;
    }

    public void OnGet(long id)
    {
        _Command = ProductApplication.GetDetail(id);
        _Command.Products = _AdminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            _Command.Products = _AdminQuery.GetViewModels();
            return Page();
        }

        ProductApplication.Update(_Command);
        return RedirectToPage("./index");
    }
}
