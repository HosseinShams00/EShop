using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class CreateModel : PageModel
{
    [BindProperty] public DefineCustomerDiscount Command { get; set; }
    private readonly ICustomerDiscountApplication _application;

    public CreateModel(ICustomerDiscountApplication productCategoryApplication)
    {
        _application = productCategoryApplication;
    }

    public void OnGet()
    {
        Command = new();
        Command.StartDateTime = DateTime.Now;
        Command.EndDateTime = DateTime.Now;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _application.Create(Command);
        return RedirectToPage("./index");
    }
}
