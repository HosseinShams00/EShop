using BaseFramwork.Repository;
using InventoryManager.Applicaton.Contracts.InventoryAgg;
using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;
using InventoryManager.Applicaton.Contracts.InventoryOperationAgg;

namespace InventoryManager.Domain.InventoryAgg;

public interface IInventoryRepository : IBaseRepository<long, Inventory>
{
}

