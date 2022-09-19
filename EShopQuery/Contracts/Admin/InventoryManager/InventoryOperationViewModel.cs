namespace EShopQuery.Contracts.Admin.InventoryManager;

public class InventoryOperationViewModel
{
    public long Id { get; set; }
    public DateTime OperationDate { get; set; }
    public int Count { get; set; }
    public long OperatorId { get; set; }
    public long CurrentCount { get; set; }
    public string Description { get; set; }
    public long OrderId { get; set; }
}
