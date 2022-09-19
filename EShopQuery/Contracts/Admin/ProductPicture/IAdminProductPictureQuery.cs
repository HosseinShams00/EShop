using ShopManagement.Application.Constracts.ProductPictureAgg.Command;
using ShopManagement.Application.Constracts.ProductPictureAgg;

namespace EShopQuery.Contracts.Admin.ProductPicture;

public interface IAdminProductPictureQuery
{
    EditProductPicture GetDetail(long id);
    List<ProductPictureViewModel> GetViewModels();
}
