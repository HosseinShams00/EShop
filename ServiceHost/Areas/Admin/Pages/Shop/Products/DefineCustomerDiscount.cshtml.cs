using DiscountManager.Application.Contracts.CustommerDiscountAgg;
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

    private readonly IProductCustomerDiscountApplication productCustomerDiscountApplication;

    public List<CustomerDiscountViewModel> ViewModels { get; private set; }
    [BindProperty] public EditProdcutCustomerCommand Command { get; set; }

    public DefineCustomerDiscountModel(IProductCustomerDiscountApplication productCustomerDiscountApplication,
                                        IAdminCustomerDiscountQuery adminDiscountQuery,
                                        IAdminProductCustomerDiscountQuery adminProductDiscountQuery)
    {
        this.productCustomerDiscountApplication = productCustomerDiscountApplication;
        Command = new();
        _AdminDiscountQuery = adminDiscountQuery;
        _AdminProductDiscountQuery = adminProductDiscountQuery;
    }

    public void OnGet(long productId)
    {
        ViewModels = _AdminDiscountQuery.GetViewModels();
        Command = _AdminProductDiscountQuery.GetEditCommand(productId);
    }

    public IActionResult OnPost()
    {
        if (Command.CustomerDiscountId == 0)
        {
            if (Command.Id != 0)
                productCustomerDiscountApplication.DeleteBy(Command.ProductId);

            return RedirectToPage("./index");

        }
        if (Command.Id == 0)
        {
            productCustomerDiscountApplication.Create(new ProdcutCustomerCommand()
            {
                ProductId = Command.ProductId,
                CustomerDiscountId = Command.CustomerDiscountId
            });
            return RedirectToPage("./index");

        }

        productCustomerDiscountApplication.Update(Command);
        return RedirectToPage("./index");
    }

}
