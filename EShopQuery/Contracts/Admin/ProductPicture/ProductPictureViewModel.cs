namespace EShopQuery.Contracts.Admin.ProductPicture;

public class ProductPictureViewModel
{
    public long Id { get; set; }
    public string Path { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
    public long ProductId { get; set; }
    public bool IsRemoved { get; set; }
    public string CreationTime { get; set; }
    public string? ProductName { get; set; }

}
