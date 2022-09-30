using InventoryManager.Domain.InventoryAgg;

namespace InventoryManager.Domain.InventoryOperationAgg;

public class InventoryOperation : IInventoryOperation
{
    public long Id { get; private set; }
    public DateTime OperationDate { get; private set; }
    public int Count { get; private set; }
    public long OperatorId { get; private set; }
    public long CurrentCount { get; private set; }
    public string? Description { get; private set; }
    public long OrderId { get; private set; }
    public long InventoryId { get; private set; }
    public Inventory Inventory { get; private set; }

    public InventoryOperation(int count, long operatorId,
                              long currentCount, string? description,
                              long orderId, long inventoryId)
    {
        Count = count;
        OperatorId = operatorId;
        CurrentCount = currentCount;
        Description = description;
        OrderId = orderId;
        InventoryId = inventoryId;
        OperationDate = DateTime.Now;
    }

    public void Edit(int count, long operatorId,
                     long currentCount, string? description,
                     long orderId, long inventoryId)
    {
        Count = count;
        OperatorId = operatorId;
        CurrentCount = currentCount;
        Description = description;
        OrderId = orderId;
        InventoryId = inventoryId;
    }

}