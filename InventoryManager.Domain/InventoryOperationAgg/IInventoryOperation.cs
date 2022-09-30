namespace InventoryManager.Domain.InventoryOperationAgg;

public interface IInventoryOperation
{
    public long Id { get; }
    public DateTime OperationDate { get; }
    public int Count { get; }
    public long OperatorId { get; }
    public long CurrentCount { get; }
    public string? Description { get; }
    public long OrderId { get; }
    public long InventoryId { get; }
}