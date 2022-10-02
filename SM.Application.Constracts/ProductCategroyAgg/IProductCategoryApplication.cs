using ShopManagement.Application.Contract.ProductCategroyAgg.Command;

namespace ShopManagement.Application.Contract.ProductCategroyAgg;

public interface IProductCategoryApplication
{
    void Create(CreateProductCategory createProductCategory);
    void Update(EditProductCategory editProductCategory);
    void Delete(long id);
    void Restore(long id);
}
