using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class IndexModel : PageModel
{
    private readonly ICustomerDiscountApplication _Application;
    public List<CustomerDiscountViewModel> ViewModel { get; set; } = new();

    public IndexModel(ICustomerDiscountApplication application)
    {
        this._Application = application;
    }

    public void OnGet()
    {
        ViewModel = _Application.GetViewModels();
    }
}
