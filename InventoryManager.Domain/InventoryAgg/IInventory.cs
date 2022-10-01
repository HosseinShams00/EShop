using BaseFramework.Domain;

namespace InventoryManager.Domain.InventoryAgg;

public interface IInventory : IBaseDomain
{
    public int UnitPrice { get; }
    public long CurrentCount { get; }
}