using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class EditModel : PageModel
{
    [BindProperty] public EditCustomerDiscount _Command { get; set; }
    private readonly ICustomerDiscountApplication _Application;
    private readonly IAdminCustomerDiscountQuery _AdminDiscountQuery;

    public EditModel(ICustomerDiscountApplication productCategoryApplication, IAdminCustomerDiscountQuery adminDiscountQuery)
    {
        _Application = productCategoryApplication;
        _AdminDiscountQuery = adminDiscountQuery;
    }

    public void OnGet(long id)
    {
        _Command = _AdminDiscountQuery.GetDetail(id);
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _Application.Update(_Command);
        return RedirectToPage("./index");
    }
}
