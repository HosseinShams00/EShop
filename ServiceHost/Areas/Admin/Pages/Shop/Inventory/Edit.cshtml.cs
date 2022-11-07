using BaseFramework.Application.Exceptions;
using EShopQuery.Contracts.Admin.InventoryManager;
using InventoryManager.Application.Contract.InventoryAgg;
using InventoryManager.Application.Contract.InventoryAgg.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class EditModel : PageModel
{

    private readonly IAdminInventoryQuery _adminQuery;
    private readonly IInventoryApplication _application;
    [BindProperty] public EditInventoryCommand Command { get; set; }

    public EditModel(IAdminInventoryQuery adminQuery, IInventoryApplication application)
    {
        _adminQuery = adminQuery;
        _application = application;
    }

    public void OnGet(long id)
    {
        Command = _adminQuery.GetDetails(id) ?? throw new EntityNotFoundException();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _application.Update(Command);
        return RedirectToPage("./index");

    }

}
