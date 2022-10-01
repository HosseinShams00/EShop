using InventoryManager.Domain.InventoryOperationAgg;

namespace EShopQuery.Contracts.DbContract;

public class InventoryOperationQuery : IInventoryOperation
{
    public long Id { get; set; }
    public DateTime OperationDate { get; set; }
    public int Count { get; set; }
    public long OperatorId { get; set; }
    public long CurrentCount { get; set; }
    public string? Description { get; set; }
    public long OrderId { get; set; }
    public long InventoryId { get; set; }

    public InventoryQuery? InventoryQuery { get; set; }
    public List<InventoryOperationQuery> InventoryOperationQueries { get; set; } = new();

}