using BaseFramwork.Application.Exceptions;
using EShopQuery.Contracts.Admin.InventoryManager;
using InventoryManager.Applicaton.Contracts.InventoryAgg;
using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class EditModel : PageModel
{

    private readonly IAdminInventoryQuery _AdminQuery;
    private readonly IInventoryApplication _Application;
    [BindProperty] public EditInventoryCommand _Command { get; set; }

    public EditModel(IAdminInventoryQuery adminQuery, IInventoryApplication application)
    {
        _AdminQuery = adminQuery;
        _Application = application;
    }

    public void OnGet(long id)
    {
        _Command = _AdminQuery.GetDetails(id) ?? throw new EntityNotFoundException();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _Application.Update(_Command);
        return RedirectToPage("./index");

    }

}
