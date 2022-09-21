using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;

namespace EShopQuery.Contracts.Admin.InventoryManager;

public interface IAdminInventoryQuery
{
    EditInventoryCommand? GetDetails(long id);
    List<InventoryViewModel> GetViewModels();
    List<InventoryViewModel> GetViewModels(InventorySearchModel searchModel);
    List<InventoryOperationViewModel> GetOperationViewModels(long inventoryId);
    long GetInventoryIdWith(long productId);
}
