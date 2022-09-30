using BaseFramework.Domain;

namespace ShopManagement.Domain.SliderAgg;

public interface ISlider : IBaseDomain
{
    public string PicturePath { get; }
    public string? PictureAlt { get; }
    public string? PictureTitle { get; }
    public string? Heading { get; }
    public string? Title { get; }
    public string? BodyText { get; }
    public string ButtonText { get; }
    public string RedirectUrl { get; }
}