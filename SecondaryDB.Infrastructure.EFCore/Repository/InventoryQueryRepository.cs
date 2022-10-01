using BaseFramework.Repository;
using SecondaryDB.Domain;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class InventoryQueryRepository : BaseQueryRepository<long, InventoryQuery>, IInventoryQueryRepository
{
    public InventoryQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}
