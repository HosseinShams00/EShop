using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;

namespace ShopManagement.Domain.ProductAgg;

public interface IProductRepository : IBaseRepository<long, Product>
{
    EditProduct? GetDetail(long id);
    List<ProductViewModel> Search(ProductSearchModel productSearchModel);
    List<ProductViewModel> GetViewModels();

}