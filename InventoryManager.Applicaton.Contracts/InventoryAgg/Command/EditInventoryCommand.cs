namespace InventoryManager.Applicaton.Contracts.InventoryAgg.Command;

public class EditInventoryCommand 
{
    public long Id { get; set; }
    public int UnitPrice { get; set; }
}