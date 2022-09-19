using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class ProductCustomerListModel : PageModel
{
    private readonly IAdminProductCustomerDiscountQuery _AdminQuery;

    public List<ProductCustomerDiscountViewModel> ViewModels { get; private set; }

    public ProductCustomerListModel(IAdminProductCustomerDiscountQuery adminQuery)
    {
        _AdminQuery = adminQuery;
    }

    public void OnGet(long customerDiscountId)
    {
        ViewModels = _AdminQuery.GetProductsViewModels(customerDiscountId);
    }

}
