using InventoryManager.Domain.InventoryAgg;
using SecondaryDB.Domain.ProductQueryAgg;

namespace SecondaryDB.Domain.InventoryQueryAgg;

public class InventoryQuery : IInventory
{
    public long Id { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsRemoved { get; set; }
    public int UnitPrice { get; set; }
    public long CurrentCount { get; set; }
    public long ProductId { get; set; }

    public ProductQuery? ProductQuery { get; set; }
    public List<InventoryOperationQuery> InventoryOperationQueries { get; set; } = new();

}