using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class IndexModel : PageModel
{
    private readonly ICustomerDiscountApplication _Application;
    public List<CustomerDiscountViewModel> ViewModels { get; set; } = new();

    public IndexModel(ICustomerDiscountApplication application)
    {
        _Application = application;
    }

    public void OnGet()
    {
        ViewModels = _Application.GetViewModels();
    }
}
