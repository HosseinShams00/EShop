namespace EShopQuery.Contracts.Admin.Slider;

public class SliderQueryModel
{
    public long Id { get; set; }
    public string PicturePath { get; set; }
    public string? Heading { get; set; }
    public string RedirectUrl { get; set; }
    public string CreationTime { get; set; }
    public bool IsRemoved { get; set; }
}