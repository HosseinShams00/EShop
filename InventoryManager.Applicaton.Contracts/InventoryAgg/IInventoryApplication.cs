using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;
using InventoryManager.Applicaton.Contracts.InventoryOperationAgg.Command;

namespace InventoryManager.Applicaton.Contracts.InventoryAgg;

public interface IInventoryApplication
{
    void Create(CreateInventoryCommand command);
    void Update(EditInventoryCommand editProduct);
    void AddNewOperation(CreateInventoryOperationCommand operationCommand);
}
