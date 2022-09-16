namespace DiscountManager.Domain.ProductCustomerDiscountAgg;

public interface IProductCustomerDiscountValidator
{
    void CheckCustomerDiscountId(long id);
    void CheckProductId(long id);
}
