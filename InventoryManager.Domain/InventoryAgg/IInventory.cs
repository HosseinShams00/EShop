using BaseFramework.Domain;

namespace InventoryManager.Domain.InventoryAgg;

public interface IInventory : IBaseDomain
{
    public long ProductId { get; }
    public int UnitPrice { get; }
    public long CurrentCount { get; }
}