using BaseFramwork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg;

public class ProductPicture : ProductPictureBase
{
    public string Path { get; private set; }
    public string? PictureAlt { get; private set; }
    public string? PictureTitle { get; private set; }
    public long ProductId { get; private set; }
    public Product Product { get; set; }
    protected ProductPicture()
    {

    }

    public ProductPicture(string path, string pictureAlt, string pictureTitle, long productId , IProductPictureValidator validator)
    {
        Path = path;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        validator.CheckProductExist(productId);
        ProductId = productId;
    }

    public void Edit(string path, string pictureAlt, string pictureTitle, long productId, IProductPictureValidator validator)
    {
        Path = path;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        validator.CheckProductExist(productId);
        ProductId = productId;
    }
}
