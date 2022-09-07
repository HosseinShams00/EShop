using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ShopManagement.Domain.ProductPictureAgg;

public interface IProductPictureRepository : IBaseRepository<long , ProductPicture>
{
    EditProductPicture? GetDetail(long id);
    List<ProductPictureViewModel> GetViewModels();
}
