using InventoryManager.Application.Contract.InventoryAgg.Command;

namespace EShopQuery.Contracts.Admin.InventoryManager;

public interface IAdminInventoryQuery
{
    EditInventoryCommand? GetDetails(long id);
    List<InventoryQueryModel> GetViewModels();
    List<InventoryQueryModel> GetViewModels(InventorySearchModel searchModel);
    List<InventoryOperationQueryModel> GetOperationViewModels(long inventoryId);
}
