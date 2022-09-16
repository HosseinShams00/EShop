using BaseFramwork.Repository;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using System.Linq.Expressions;

namespace DiscountManager.Domain.ProductCustomerDiscountAgg;

public interface IProductCustomerDiscountRepository : IBaseRepository<long , ProductCustomerDiscount>
{
    void RemoveBy(long productId);
    List<ProductCustomerDiscountViewModel> GetProductsViewModels(long customerDiscountId);
    long GetCustomerDiscountId(long productId);
    EditProdcutCustomerCommand? GetEditCommand(long productId);
}
