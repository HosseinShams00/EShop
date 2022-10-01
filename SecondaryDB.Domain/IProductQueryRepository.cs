using BaseFramework.Repository;

namespace SecondaryDB.Domain;

public interface IProductQueryRepository : IBaseQueryRepository<long, ProductQuery>
{
}