using BaseFramework.Repository;

namespace SecondaryDB.Domain.CustomerDiscountQueryAgg;

public interface ICustomerDiscountQueryRepository : IBaseQueryRepository<long, CustomerDiscountQuery>
{
}
