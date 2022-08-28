using ShopManagement.Application.Constracts.ProductCategroy;
using ShopManagement.Application.Constracts.ProductCategroy.Command;
using System.Linq.Expressions;


namespace ShopManagement.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository
{
    void Create(ProductCategory productCategory);
    ProductCategory GetBy(long id);
    List<ProductCategory> GetProducts();
    bool Exist(Expression<Func<ProductCategory , bool>> expression);
    void SaveChanges();
    EditProductCategory GetDetail(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel);
}
