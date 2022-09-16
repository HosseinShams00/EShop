using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;

namespace DiscountManager.Application.Contracts.CustommerDiscountAgg;

public interface ICustomerDiscountApplication
{
    EditCustomerDiscount GetDetail(long id);
    void Create(DefineCustomerDiscount customerDiscount);
    void Update(EditCustomerDiscount editProduct);
    void Delete(long id);
    void Restore(long id);
    List<CustomerDiscountViewModel> GetViewModels();
}
