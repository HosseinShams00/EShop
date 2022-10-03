using BaseFramework.Domain.BaseDomainAgg;

namespace InventoryManager.Domain.InventoryAgg;

public interface IInventory : IBaseDomain
{
    public int UnitPrice { get; }
    public long CurrentCount { get; }
}