using BaseFramework.Repository;

namespace SecondaryDB.Domain;

public interface ICustomerDiscountQueryRepository : IBaseQueryRepository<long, CustomerDiscountQuery>
{
}
