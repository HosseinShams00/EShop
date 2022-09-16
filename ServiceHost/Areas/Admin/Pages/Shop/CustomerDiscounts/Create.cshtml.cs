using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class CreateModel : PageModel
{
    [BindProperty] public DefineCustomerDiscount _Command { get; set; }
    private readonly ICustomerDiscountApplication _Application;

    public CreateModel(ICustomerDiscountApplication productCategoryApplication)
    {
        _Application = productCategoryApplication;
    }

    public void OnGet()
    {
        _Command = new();
        _Command.StartDateTime = DateTime.Now;
        _Command.EndDateTime = DateTime.Now;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _Application.Create(_Command);
        return RedirectToPage("./index");
    }
}
