using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class IndexModel : PageModel
{
    private readonly ICustomerDiscountApplication _Application;
    private readonly IAdminDiscountQuery _AdminDiscountQuery;

    public List<CustomerDiscountViewModel> ViewModels { get; set; } = new();

    public IndexModel(ICustomerDiscountApplication application, IAdminDiscountQuery adminDiscountQuery)
    {
        _Application = application;
        _AdminDiscountQuery = adminDiscountQuery;
    }

    public void OnGet()
    {
        ViewModels = _AdminDiscountQuery.GetViewModels();
    }
}
