using BaseFramwork.Domain;

namespace ShopManagement.Domain.SliderAgg;

public class Slider : BaseDomain
{
   
    public string PicturePath { get; private set; }
    public string? PictureAlt { get; private set; }
    public string? PictureTitle { get; private set; }
    public string? Heading { get; private set; }
    public string? Title { get; private set; }
    public string? BodyText { get; private set; }
    public string ButtonText { get; private set; }
    public string RedirectUrl { get; private set; }

    public Slider(string picturePath, string? pictureAlt,
        string? pictureTitle, string? heading,
        string? title, string? bodyText,
        string buttonText, string redirectUrl)
    {
        PicturePath = picturePath;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Heading = heading;
        Title = title;
        BodyText = bodyText;
        ButtonText = buttonText;
        RedirectUrl = redirectUrl;
    }

    public void Edit(string picturePath, string? pictureAlt,
       string? pictureTitle, string? heading,
       string? title, string? bodyText,
       string buttonText, string redirectUrl)
    {
        PicturePath = picturePath;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Heading = heading;
        Title = title;
        BodyText = bodyText;
        ButtonText = buttonText;
        RedirectUrl = redirectUrl;
    }

}
