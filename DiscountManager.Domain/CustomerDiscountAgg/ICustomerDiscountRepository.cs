using BaseFramework.Repository;

namespace DiscountManager.Domain.CustomerDiscountAgg;

public interface ICustomerDiscountRepository : IBaseRepository<long , CustomerDiscount>
{
}
