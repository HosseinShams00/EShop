using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.ProductCategroy;
using ShopManagement.Application.Constracts.ProductCategroy.Command;
using System.Linq.Expressions;


namespace ShopManagement.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository : IBaseRepository<long , ProductCategory>
{
    EditProductCategory GetDetail(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel);
}
