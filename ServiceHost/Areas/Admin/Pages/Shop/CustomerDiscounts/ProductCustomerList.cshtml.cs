using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class ProductCustomerListModel : PageModel
{
    private readonly IAdminProductCustomerDiscountQuery _AdminQuery;
    private readonly IProductCustomerDiscountApplication _Application;

    public IReadOnlyCollection<ProductCustomerDiscountViewModel> ViewModels { get; private set; }
    public long _CustomerDiscountId { get; set; }


    public ProductCustomerListModel(IAdminProductCustomerDiscountQuery adminQuery, IProductCustomerDiscountApplication application)
    {
        _AdminQuery = adminQuery;
        _Application = application;
    }

    public void OnGet(long customerDiscountId)
    {
        _CustomerDiscountId = customerDiscountId;
        ViewModels = _AdminQuery.GetProductsViewModels(customerDiscountId);
    }
    public void OnGetRemove(long id, long customerDiscountId)
    {
        _Application.DeleteBy(id);
        ViewModels = _AdminQuery.GetProductsViewModels(customerDiscountId);

    }
}
