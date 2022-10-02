namespace EShopQuery.Contracts.User.Slider;

public class SliderQueryModel
{
    public string PicturePath { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
    public string? Heading { get; set; }
    public string? Title { get; set; }
    public string? BodyText { get; set; }
    public string ButtonText { get; set; }
    public string RedirectUrl { get; set; }
}
