using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using DiscountManager.Application.CustommerDiscountAgg;
using DiscountManager.Application.ProductCustomerDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class DefineCustomerDiscountModel : PageModel
{
    private readonly ICustomerDiscountApplication _Application;
    private readonly IProductCustomerDiscountApplication productCustomerDiscountApplication;

    public List<CustomerDiscountViewModel> ViewModels { get; private set; }
    [BindProperty] public EditProdcutCustomerCommand Command { get; set; }

    public DefineCustomerDiscountModel(ICustomerDiscountApplication application, IProductCustomerDiscountApplication productCustomerDiscountApplication)
    {
        _Application = application;
        this.productCustomerDiscountApplication = productCustomerDiscountApplication;
        Command = new();
    }

    public void OnGet(long productId)
    {
        ViewModels = _Application.GetViewModels();
        Command = productCustomerDiscountApplication.GetEditCommand(productId);
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
