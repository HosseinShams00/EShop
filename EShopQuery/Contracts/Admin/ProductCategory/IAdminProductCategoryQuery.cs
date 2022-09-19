using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace EShopQuery.Contracts.Admin.ProductCategory;

public interface IAdminProductCategoryQuery
{
    EditProductCategory? GetDetail(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel);
    List<ProductCategoryViewModel> GetViewModels();
}
