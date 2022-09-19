using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;
using ShopManagement.Application.Constracts.ProductCategroyAgg;

namespace EShopQuery.Contracts.Admin.ProductCategory;

public interface IAdminProductCategoryQuery
{
    EditProductCategory? GetDetail(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel);
    List<ProductCategoryViewModel> GetViewModels();
}
