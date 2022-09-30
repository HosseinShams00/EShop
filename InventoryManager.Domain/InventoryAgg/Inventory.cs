using BaseFramework.Domain;
using InventoryManager.Domain.InventoryOperationAgg;

namespace InventoryManager.Domain.InventoryAgg;

public class Inventory : BaseDomain
{
    public long ProductId { get; private set; }
    public int UnitPrice { get; private set; }
    public long CurrentCount { get; private set; }
    public IReadOnlyCollection<InventoryOperation> Operations
    {
        get { return _operations; }
        private set
        {
            _operations = new(value);
        }
    }
    private List<InventoryOperation> _operations = new();

    protected Inventory()
    {
        Operations = new List<InventoryOperation>();
    }

    public Inventory(long productId, int unitPrice)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
    }

    public void Edit(int unitPrice)
    {
        UnitPrice = unitPrice;
    }

    public void AddNewTransAction(InventoryOperation inventoryOperation)
    {
        CurrentCount += inventoryOperation.Count;
        _operations.Add(inventoryOperation);
    }

}