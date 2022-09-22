using EShopQuery.Contracts.Admin.InventoryManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class IndexModel : PageModel
{
    private readonly IAdminInventoryQuery _AdminQuery;

    public IReadOnlyCollection<InventoryQueryModel> ViewModels { get; set; }

    public IndexModel(IAdminInventoryQuery adminQuery)
    {
        _AdminQuery = adminQuery;
    }

    public void OnGet()
    {
        ViewModels = _AdminQuery.GetViewModels();
    }
}
