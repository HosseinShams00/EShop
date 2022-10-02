using ShopManagement.Application.Contract.ProductCategroyAgg.Command;

namespace EShopQuery.Contracts.Admin.ProductCategory;

public interface IAdminProductCategoryQuery
{
    EditProductCategory? GetDetail(long id);
    List<ProductCategoryQueryModel> Search(ProductCategorySearchModel productCategorySearchModel);
    List<ProductCategoryQueryModel> GetViewModels();
}
