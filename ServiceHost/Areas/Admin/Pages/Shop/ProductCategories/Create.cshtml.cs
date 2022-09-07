using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories
{
    public class CreateModel : PageModel
    {
        [BindProperty] public CreateProductCategory createProductCategory { get; set; }
        private readonly IProductCategoryApplication productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            createProductCategory = new();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();

            productCategoryApplication.Create(createProductCategory);
            return RedirectToPage("./index");
        }

    }
}
