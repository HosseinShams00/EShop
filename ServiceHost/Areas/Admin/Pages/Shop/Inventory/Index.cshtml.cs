using EShopQuery.Contracts.Admin.InventoryManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.Inventory;

public class IndexModel : PageModel
{
    private readonly IAdminInventoryQuery _adminQuery;

    public IReadOnlyCollection<InventoryQueryModel> ViewModels { get; set; }

    public IndexModel(IAdminInventoryQuery adminQuery)
    {
        _adminQuery = adminQuery;
    }

    public void OnGet()
    {
        ViewModels = _adminQuery.GetViewModels();
    }
}
