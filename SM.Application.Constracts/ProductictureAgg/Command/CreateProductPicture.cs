namespace ShopManagement.Application.Constracts.ProductPictureAgg.Command;

public class CreateProductPicture
{
    public string Path { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public long ProductId { get; set; }
}