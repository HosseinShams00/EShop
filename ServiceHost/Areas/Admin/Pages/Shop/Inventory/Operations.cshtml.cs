using EShopQuery.Contracts.Admin.InventoryManager;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class OperationsModel : PageModel
{
    private readonly IAdminInventoryQuery _AdminQuery;

    public IReadOnlyCollection<InventoryOperationQueryModel> ViewModels { get; set; }
    public long InventoryId { get; set; }

    public OperationsModel(IAdminInventoryQuery adminQuery)
    {
        _AdminQuery = adminQuery;
    }


    public void OnGet(long id)
    {
        ViewModels = _AdminQuery.GetOperationViewModels(id);
        InventoryId = id;
    }
}
