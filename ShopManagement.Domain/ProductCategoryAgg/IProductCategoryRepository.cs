using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;


namespace ShopManagement.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository : IBaseRepository<long , ProductCategory>
{
    EditProductCategory? GetDetail(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel);
    List<ProductCategoryViewModel> GetViewModels();
}
