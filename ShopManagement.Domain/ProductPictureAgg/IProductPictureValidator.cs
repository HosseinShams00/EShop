using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg.Exceptions;

namespace ShopManagement.Domain.ProductPictureAgg;

public interface IProductPictureValidator
{
    void CheckProductExist(long id);
}

public class ProductPictureValidator : IProductPictureValidator
{
    private readonly IProductRepository ProductReository;

    public ProductPictureValidator(IProductRepository productReository)
    {
        ProductReository = productReository;
    }
    public void CheckProductExist(long id)
    {
        if (ProductReository.Exist(x => x.Id == id) == false)
            throw new ProductIdNotExistException();
    }
}