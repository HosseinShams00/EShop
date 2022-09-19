using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace ShopManagement.Application.Constracts.ProductCategroyAgg;

public interface IProductCategoryApplication
{
    void Create(CreateProductCategory createProductCategory);
    void Update(EditProductCategory editProductCategory);
    void Delete(long id);
    void Restore(long id);
}
