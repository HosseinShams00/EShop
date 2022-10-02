using ShopManagement.Application.Contract.ProductPictureAgg.Command;

namespace ShopManagement.Application.Contract.ProductPictureAgg;

public interface IProductPictureApplication
{
    void Create(CreateProductPicture createProductPicture);
    void Update(EditProductPicture editProductPicture);
    void Delete(long id);
    void Restore(long id);
}