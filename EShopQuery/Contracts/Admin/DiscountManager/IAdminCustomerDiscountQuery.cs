using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;

namespace EShopQuery.Contracts.Admin.DiscountManager;

public interface IAdminCustomerDiscountQuery
{
    EditCustomerDiscount? GetDetail(long id);
    List<CustomerDiscountViewModel> GetViewModels();
}

