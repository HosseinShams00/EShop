using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;

namespace DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;

public interface IProductCustomerDiscountApplication
{
    void Create(ProdcutCustomerCommand command);
    void DeleteBy(long productId);
    long GetCustomerDiscountId(long productId);
    void Update(EditProdcutCustomerCommand editCustomerDiscount);
}
