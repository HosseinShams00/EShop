using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class ProductCustomerListModel : PageModel
{
    private readonly IProductCustomerDiscountApplication _Application;
    public List<ProductCustomerDiscountViewModel> ViewModel { get; private set; }


    public ProductCustomerListModel(IProductCustomerDiscountApplication application)
    {
        this._Application = application;
    }


    public void OnGet(long customerDiscountId)
    {
        ViewModel = _Application.GetProductsViewModels(customerDiscountId);
    }
}
