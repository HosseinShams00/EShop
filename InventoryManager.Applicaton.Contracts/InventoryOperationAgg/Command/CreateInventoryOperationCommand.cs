namespace InventoryManager.Application.Contract.InventoryOperationAgg.Command;

public class CreateInventoryOperationCommand
{
    public int Count { get; set; }
    public long OperatorId { get; set; }
    public long CurrentCount { get; set; }
    public string? Description { get; set; }
    public long OrderId { get; set; }
    public long InventoryId { get; set; }
}
