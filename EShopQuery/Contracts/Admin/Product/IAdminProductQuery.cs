using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Application.Constracts.ProductAgg;

namespace EShopQuery.Contracts.Admin.Product;

public interface IAdminProductQuery
{
    EditProduct GetDetail(long id);
    List<ProductViewModel> Search(ProductSearchModel productSearchModel);
    List<ProductViewModel> GetViewModels();
}
