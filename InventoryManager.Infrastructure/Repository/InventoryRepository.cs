using BaseFramwork.Repository;
using InventoryManager.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.EFCore.Repository;

public class InventoryRepository : BaseRepository<long, Inventory> , IInventoryRepository
{
    public InventoryRepository(InventoryEFCoreDbContext context) : base(context)
    {
    }
}
