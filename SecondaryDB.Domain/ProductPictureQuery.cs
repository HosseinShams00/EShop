using ShopManagement.Domain.ProductPictureAgg;

namespace SecondaryDB.Domain;

public class ProductPictureQuery : IProductPicture
{
    public long Id { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsRemoved { get; set; }
    public string Path { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
    public long ProductId { get; set; }

    public ProductQuery? ProductQuery { get; set; }
}