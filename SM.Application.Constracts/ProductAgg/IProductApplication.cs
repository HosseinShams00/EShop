using ShopManagement.Application.Constracts.ProductAgg.Command;

namespace ShopManagement.Application.Constracts.ProductAgg;

public interface IProductApplication
{
    void Create(CreateProduct createProduct);
    void Update(EditProduct editProduct);
    void Delete(long id);
    void Restore(long id);
}
