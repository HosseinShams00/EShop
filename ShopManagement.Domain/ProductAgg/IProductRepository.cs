using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.Product.Command;

namespace ShopManagement.Domain.ProductAgg;

public interface IProductRepository : IBaseRepository<long, LaptopProduct>
{
    void Create(CreateProduct createProduct);
    EditProduct? GetDetail(long id);
    List<ProductViewModel> Search(ProductSearchModel productCategorySearchModel);
}