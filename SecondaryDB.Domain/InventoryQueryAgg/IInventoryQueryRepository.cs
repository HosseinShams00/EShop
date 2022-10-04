using BaseFramework.Repository;

namespace SecondaryDB.Domain.InventoryQueryAgg;

public interface IInventoryQueryRepository : IBaseQueryRepository<long, InventoryQuery>
{
}

