using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;

namespace EShopQuery.Contracts.Admin.DiscountManager;

public interface IAdminProductCustomerDiscountQuery
{
    EditProdcutCustomerCommand? GetEditCommand(long productId);
    List<ProductCustomerDiscountViewModel> GetProductsViewModels(long customerDiscountId);
}
