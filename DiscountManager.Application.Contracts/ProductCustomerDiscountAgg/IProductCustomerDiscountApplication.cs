using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;

namespace DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;

public interface IProductCustomerDiscountApplication
{
    void Create(ProdcutCustomerCommand command);
    void DeleteBy(long productId);
    List<ProductCustomerDiscountViewModel> GetProductsViewModels(long customerDiscountId);
    long GetCustomerDiscountId(long productId);
    EditProdcutCustomerCommand GetEditCommand(long productId);
    void Update(EditProdcutCustomerCommand editCustomerDiscount);
}
