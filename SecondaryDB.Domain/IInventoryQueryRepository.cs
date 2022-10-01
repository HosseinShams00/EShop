using BaseFramework.Repository;

namespace SecondaryDB.Domain;

public interface IInventoryQueryRepository : IBaseQueryRepository<long, InventoryQuery>
{
}

