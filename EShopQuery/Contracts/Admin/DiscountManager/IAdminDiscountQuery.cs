using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;

namespace EShopQuery.Contracts.Admin.DiscountManager;

public interface IAdminDiscountQuery
{
    EditCustomerDiscount? GetDetail(long id);
    List<CustomerDiscountViewModel> GetViewModels();
}

