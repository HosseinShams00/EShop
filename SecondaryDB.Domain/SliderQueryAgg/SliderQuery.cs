using ShopManagement.Domain.SliderAgg;

namespace SecondaryDB.Domain.SliderQueryAgg;

public class SliderQuery : ISlider
{
    public long Id { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsRemoved { get; set; }
    public string PicturePath { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
    public string? Heading { get; set; }
    public string? Title { get; set; }
    public string? BodyText { get; set; }
    public string ButtonText { get; set; }
    public string RedirectUrl { get; set; }
}