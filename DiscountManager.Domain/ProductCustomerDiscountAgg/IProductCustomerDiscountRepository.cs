using BaseFramwork.Repository;

namespace DiscountManager.Domain.ProductCustomerDiscountAgg;

public interface IProductCustomerDiscountRepository : IBaseRepository<long , ProductCustomerDiscount>
{
    void RemoveBy(long productId);
    long GetCustomerDiscountId(long productId);
}
