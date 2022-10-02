using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class DefineCustomerDiscountModel : PageModel
{
    private readonly IAdminCustomerDiscountQuery _adminDiscountQuery;
    private readonly IAdminProductCustomerDiscountQuery _adminProductDiscountQuery;

    private readonly IProductCustomerDiscountApplication _productCustomerDiscountApplication;

    public IReadOnlyCollection<CustomerDiscountQueryModel> ViewModels { get; private set; }
    [BindProperty] public EditProdcutCustomerCommand Command { get; set; }

    public DefineCustomerDiscountModel(IProductCustomerDiscountApplication productCustomerDiscountApplication,
                                        IAdminCustomerDiscountQuery adminDiscountQuery,
                                        IAdminProductCustomerDiscountQuery adminProductDiscountQuery)
    {
        _productCustomerDiscountApplication = productCustomerDiscountApplication;
        Command = new();
        _adminDiscountQuery = adminDiscountQuery;
        _adminProductDiscountQuery = adminProductDiscountQuery;
    }

    public void OnGet(long productId)
    {
        ViewModels = _adminDiscountQuery.GetViewModels();
        Command = _adminProductDiscountQuery.GetEditCommand(productId) ?? new EditProdcutCustomerCommand() { ProductId = productId };
    }

    public IActionResult OnPost()
    {
        if (Command.CustomerDiscountId == 0)
        {
            if (Command.Id != 0)
                _productCustomerDiscountApplication.DeleteBy(Command.ProductId);

            return RedirectToPage("./index");

        }
        if (Command.Id == 0)
        {
            _productCustomerDiscountApplication.Create(new ProdcutCustomerCommand()
            {
                ProductId = Command.ProductId,
                CustomerDiscountId = Command.CustomerDiscountId
            });
            return RedirectToPage("./index");

        }

        _productCustomerDiscountApplication.Update(Command);
        return RedirectToPage("./index");
    }

}
