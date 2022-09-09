using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPictures;

public class EditModel : PageModel
{
    [BindProperty] public EditProductPicture editProductPicture { get; set; }
    private readonly IProductPictureApplication ProductApplication;
    private readonly IProductApplication ProductCategoryApplication;


    public EditModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
    {
        ProductApplication = productPictureApplication;
        ProductCategoryApplication = productApplication;
    }

    public void OnGet(long id)
    {
        editProductPicture = ProductApplication.GetDetail(id);
        editProductPicture.Products = ProductCategoryApplication.GetAll();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        ProductApplication.Update(editProductPicture);
        return RedirectToPage("./index");
    }
}
