using BaseFramework.Domain.ProductCustomerDiscountAgg;

namespace DiscountManager.Domain.ProductCustomerDiscountAgg;

public interface IProductCustomerDiscount : IProductCustomerDiscountBase
{
    public long ProductId { get; }
    public long CustomerDiscountId { get; }
}