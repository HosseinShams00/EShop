using InventoryManager.Applicaton.Contracts.InventoryAgg;
using InventoryManager.Applicaton.Contracts.InventoryOperationAgg.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class AddOperationModel : PageModel
{
    private readonly IInventoryApplication _Application;
    [BindProperty] public CreateInventoryOperationCommand _Command { get; set; }

    public AddOperationModel(IInventoryApplication application)
    {
        _Application = application;
        _Command = new();
    }

    public void OnGet(long inventoryId)
    {
        _Command.InventoryId = inventoryId;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _Command.OperatorId = 0;
        _Command.OrderId = 0;

        _Application.AddNewOperation(_Command);
        return RedirectToPage("./index");
    }
}
