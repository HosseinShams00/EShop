using ShopManagement.Application.Contract.ProductPictureAgg.Command;

namespace EShopQuery.Contracts.Admin.ProductPicture;

public interface IAdminProductPictureQuery
{
    EditProductPicture GetDetail(long id);
    List<ProductPictureQueryModel> GetViewModels();
}
