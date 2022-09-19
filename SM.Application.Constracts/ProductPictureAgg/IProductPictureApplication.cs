using ShopManagement.Application.Constracts.ProductPictureAgg.Command;

namespace ShopManagement.Application.Constracts.ProductPictureAgg;

public interface IProductPictureApplication
{
    void Create(CreateProductPicture createProductCategory);
    void Update(EditProductPicture editProductCategory);
    void Delete(long id);
    void Restore(long id);
}