using BaseFramwork.Application;
using ShopManagement.Application.Constracts.ProductCategroy.Command;

namespace ShopManagement.Application.Constracts.ProductCategroy;

public interface IProductCategoryApplication
{
    EditProductCategory GetDetail(long id);
    OperationResult Create(CreateProductCategory createProductCategory);
    OperationResult Update(EditProductCategory editProductCategory);
    void Delete(long id);
    void Restore(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel);
}
