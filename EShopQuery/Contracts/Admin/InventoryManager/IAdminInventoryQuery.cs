using InventoryManager.Applicaton.Contracts.InventoryAgg;
using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;
using InventoryManager.Applicaton.Contracts.InventoryOperationAgg;

namespace EShopQuery.Contracts.Admin.InventoryManager;

public interface IAdminInventoryQuery
{
    EditInventoryCommand? GetDetails(long id);
    List<InventoryViewModel> GetViewModels();
    List<InventoryViewModel> GetViewModels(InventorySearchModel searchModel);
    List<InventoryOperationViewModel> GetOperationViewModels(long inventoryId);
}
