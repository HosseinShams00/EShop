using BaseFramework.Repository;
using InventoryManager.Domain.InventoryAgg;

namespace InventoryManager.Infrastructure.EFCore.Repository;

public class InventoryRepository : BaseRepository<long, Inventory>, IInventoryRepository
{
    public InventoryRepository(InventoryEFCoreDbContext context) : base(context)
    {
    }
}
