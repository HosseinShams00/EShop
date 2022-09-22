using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;

namespace EShopQuery.Contracts.Admin.DiscountManager;

public interface IAdminProductCustomerDiscountQuery
{
    EditProdcutCustomerCommand? GetEditCommand(long productId);
    List<ProductCustomerDiscountQueryModel> GetProductsViewModels(long customerDiscountId);
}
