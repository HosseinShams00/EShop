using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditProductCategory editProductCategory { get; set; }
        private readonly IProductCategoryApplication productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(long id)
        {
            editProductCategory = productCategoryApplication.GetDetail(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
                return Page();

            productCategoryApplication.Update(editProductCategory);
            return RedirectToPage("./index");
        }
    }
}
