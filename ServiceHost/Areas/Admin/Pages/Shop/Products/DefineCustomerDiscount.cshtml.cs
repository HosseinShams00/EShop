using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class DefineCustomerDiscountModel : PageModel
{
    private readonly IAdminCustomerDiscountQuery _AdminDiscountQuery;
    private readonly IAdminProductCustomerDiscountQuery _AdminProductDiscountQuery;

    private readonly IProductCustomerDiscountApplication _ProductCustomerDiscountApplication;

    public IReadOnlyCollection<CustomerDiscountViewModel> ViewModels { get; private set; }
    [BindProperty] public EditProdcutCustomerCommand _Command { get; set; }

    public DefineCustomerDiscountModel(IProductCustomerDiscountApplication productCustomerDiscountApplication,
                                        IAdminCustomerDiscountQuery adminDiscountQuery,
                                        IAdminProductCustomerDiscountQuery adminProductDiscountQuery)
    {
        _ProductCustomerDiscountApplication = productCustomerDiscountApplication;
        _Command = new();
        _AdminDiscountQuery = adminDiscountQuery;
        _AdminProductDiscountQuery = adminProductDiscountQuery;
    }

    public void OnGet(long productId)
    {
        ViewModels = _AdminDiscountQuery.GetViewModels();
        _Command = _AdminProductDiscountQuery.GetEditCommand(productId) ?? new EditProdcutCustomerCommand() { ProductId = productId };
    }

    public IActionResult OnPost()
    {
        if (_Command.CustomerDiscountId == 0)
        {
            if (_Command.Id != 0)
                _ProductCustomerDiscountApplication.DeleteBy(_Command.ProductId);

            return RedirectToPage("./index");

        }
        if (_Command.Id == 0)
        {
            _ProductCustomerDiscountApplication.Create(new ProdcutCustomerCommand()
            {
                ProductId = _Command.ProductId,
                CustomerDiscountId = _Command.CustomerDiscountId
            });
            return RedirectToPage("./index");

        }

        _ProductCustomerDiscountApplication.Update(_Command);
        return RedirectToPage("./index");
    }

}
