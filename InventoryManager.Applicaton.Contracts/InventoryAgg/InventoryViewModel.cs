namespace InventoryManager.Applicaton.Contracts.InventoryAgg;

public class InventoryViewModel
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public long ProductId { get; set; }
    public int UnitPrice { get; set; }
    public long CurrentCount { get; set; }
}
