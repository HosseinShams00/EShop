using InventoryManager.Application.Contract.InventoryAgg;
using InventoryManager.Application.Contract.InventoryOperationAgg.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class AddOperationModel : PageModel
{
    private readonly IInventoryApplication _application;
    [BindProperty] public CreateInventoryOperationCommand Command { get; set; }

    public AddOperationModel(IInventoryApplication application)
    {
        _application = application;
        Command = new();
    }

    public void OnGet(long inventoryId)
    {
        Command.InventoryId = inventoryId;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        Command.OperatorId = 0;
        Command.OrderId = 0;

        _application.AddNewOperation(Command);
        return RedirectToPage("./index");
    }
}
