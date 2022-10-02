using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class ProductCustomerListModel : PageModel
{
    private readonly IAdminProductCustomerDiscountQuery _adminQuery;
    private readonly IProductCustomerDiscountApplication _application;

    public IReadOnlyCollection<ProductCustomerDiscountQueryModel> ViewModels { get; private set; }
    public long CustomerDiscountId { get; set; }


    public ProductCustomerListModel(IAdminProductCustomerDiscountQuery adminQuery, IProductCustomerDiscountApplication application)
    {
        _adminQuery = adminQuery;
        _application = application;
    }

    public void OnGet(long customerDiscountId)
    {
        CustomerDiscountId = customerDiscountId;
        ViewModels = _adminQuery.GetProductsViewModels(customerDiscountId);
    }
    public void OnGetRemove(long id, long customerDiscountId)
    {
        _application.DeleteBy(id);
        ViewModels = _adminQuery.GetProductsViewModels(customerDiscountId);

    }
}
