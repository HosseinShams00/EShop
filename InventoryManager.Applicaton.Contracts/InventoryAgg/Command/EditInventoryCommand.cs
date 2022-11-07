namespace InventoryManager.Application.Contract.InventoryAgg.Command;

public class EditInventoryCommand
{
    public long Id { get; set; }
    public int UnitPrice { get; set; }
}