using InventoryManager.Application.Contract.InventoryAgg.Command;
using InventoryManager.Application.Contract.InventoryOperationAgg.Command;

namespace InventoryManager.Application.Contract.InventoryAgg;

public interface IInventoryApplication
{
    void Create(CreateInventoryCommand command);
    void Update(EditInventoryCommand editProduct);
    void AddNewOperation(CreateInventoryOperationCommand operationCommand);
}
