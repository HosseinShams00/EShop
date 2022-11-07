namespace InventoryManager.Application.Contract.InventoryAgg.Command;

public class CreateInventoryCommand
{
    public long ProductId { get; set; }
    public int UnitPrice { get; set; }
}
