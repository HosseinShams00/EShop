namespace EShopQuery.Contracts.Admin.InventoryManager;

public class InventoryQueryModel
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public long ProductId { get; set; }
    public int UnitPrice { get; set; }
    public long CurrentCount { get; set; }
}
