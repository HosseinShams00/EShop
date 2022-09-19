using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.CustomerDiscounts;

public class ProductCustomerListModel : PageModel
{
    private readonly IProductCustomerDiscountApplication _Application;
    public List<ProductCustomerDiscountViewModel> ViewModels { get; private set; }


    public ProductCustomerListModel(IProductCustomerDiscountApplication application)
    {
        _Application = application;
    }

    public void OnGet(long customerDiscountId)
    {
        ViewModels = _Application.GetProductsViewModels(customerDiscountId);
    }

}
