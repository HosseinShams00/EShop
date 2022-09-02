using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.ProductCategroy;
using ShopManagement.Application.Constracts.ProductCategroy.Command;

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

        public RedirectToPageResult OnPost()
        {
            if (ModelState.IsValid)
            {
                productCategoryApplication.Update(editProductCategory);
                return RedirectToPage("./index");
            }
            return RedirectToPage(".", new { id = editProductCategory.Id });

        }


    }
}
