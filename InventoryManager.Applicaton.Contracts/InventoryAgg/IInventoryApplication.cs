using InventoryManager.Applicaton.Contract.InventoryAgg.Command;
using InventoryManager.Applicaton.Contract.InventoryOperationAgg.Command;

namespace InventoryManager.Applicaton.Contract.InventoryAgg;

public interface IInventoryApplication
{
    void Create(CreateInventoryCommand command);
    void Update(EditInventoryCommand editProduct);
    void AddNewOperation(CreateInventoryOperationCommand operationCommand);
}
