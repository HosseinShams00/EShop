using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class EditModel : PageModel
{
    [BindProperty] public EditCustomerDiscount Command { get; set; }
    private readonly ICustomerDiscountApplication _application;
    private readonly IAdminCustomerDiscountQuery _adminDiscountQuery;

    public EditModel(ICustomerDiscountApplication productCategoryApplication, IAdminCustomerDiscountQuery adminDiscountQuery)
    {
        _application = productCategoryApplication;
        _adminDiscountQuery = adminDiscountQuery;
    }

    public void OnGet(long id)
    {
        Command = _adminDiscountQuery.GetDetail(id);
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _application.Update(Command);
        return RedirectToPage("./index");
    }
}
