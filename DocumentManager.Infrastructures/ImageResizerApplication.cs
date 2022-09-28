using DocumentManager.Application.Contracts.ImageManager.ImageSizeManager;
using DocumentManager.Application.Contracts.ImageManager.ImageSizeManager.Command;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace DocumentManager.Infrastructures;

public class ImageResizerApplication : IImageResizerApplication
{
    private const double LargeSize = 1000.0;
    private const double MediumSize = 800.0;
    private const double SmallSize = 400.0;


    public void Resize(ResizeImageCommand command)
    {

        string largeImagePath = Path.Combine(command.DirectoryPath, "large.jpeg");
        string mediumImagePath = Path.Combine(command.DirectoryPath, "medium.jpeg");
        string smallImagePath = Path.Combine(command.DirectoryPath, "small.jpeg");

        using (var image = Image.Load(command.ImageStream))
        {
            double ratio = 0;
            if (image.Width > LargeSize)
            {
                ratio = image.Width / LargeSize;
                SaveAndResizeImage(image, largeImagePath, ratio);
            }
            else
                SaveAndResizeImage(image, largeImagePath, 1);


            if (image.Width > MediumSize)
            {
                ratio = image.Width / MediumSize;
                SaveAndResizeImage(image, mediumImagePath, ratio);
            }
            else
                SaveAndResizeImage(image, mediumImagePath, 1);

            if (image.Width > SmallSize)
            {
                ratio = image.Width / SmallSize;
                SaveAndResizeImage(image, smallImagePath, ratio);
            }
            else
                SaveAndResizeImage(image, smallImagePath, 1);
        }

    }

    private static void SaveAndResizeImage(Image image, string largeImagePath, double ratio)
    {
        image.Mutate(x => { x.Resize((int)(image.Width / ratio), (int)(image.Height / ratio)); });
        image.SaveAsJpeg(largeImagePath);
    }
}