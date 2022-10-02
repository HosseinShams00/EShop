using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class IndexModel : PageModel
{
    private readonly IAdminCustomerDiscountQuery _adminDiscountQuery;

    public IReadOnlyCollection<CustomerDiscountQueryModel> ViewModels { get; set; }

    public IndexModel(IAdminCustomerDiscountQuery adminDiscountQuery)
    {
        _adminDiscountQuery = adminDiscountQuery;
    }

    public void OnGet()
    {
        ViewModels = _adminDiscountQuery.GetViewModels();
    }
}
