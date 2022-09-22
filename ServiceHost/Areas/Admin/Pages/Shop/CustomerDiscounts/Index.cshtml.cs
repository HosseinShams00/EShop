using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class IndexModel : PageModel
{
    private readonly IAdminCustomerDiscountQuery _AdminDiscountQuery;

    public IReadOnlyCollection<CustomerDiscountQueryModel> ViewModels { get; set; }

    public IndexModel(IAdminCustomerDiscountQuery adminDiscountQuery)
    {
        _AdminDiscountQuery = adminDiscountQuery;
    }

    public void OnGet()
    {
        ViewModels = _AdminDiscountQuery.GetViewModels();
    }
}
