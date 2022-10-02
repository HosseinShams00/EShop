using ShopManagement.Application.Contract.ProductAgg.Command;

namespace ShopManagement.Application.Contract.ProductAgg;

public interface IProductApplication
{
    void Create(CreateProduct createProduct);
    void Update(EditProduct editProduct);
    void Delete(long id);
    void Restore(long id);
}
