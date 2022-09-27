using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager.Commands;
using DocumentManager.Application.Contracts.ImageManager.ImageSizeManager;
using DocumentManager.Application.Contracts.ImageManager.ImageSizeManager.Command;

namespace DocumentManager.Application;

public class ImageApplication : IImageApplication
{
    private IImageResizerApplication _imageResizerApplication;

    public ImageApplication(IImageResizerApplication imageResizerApplication)
    {
        _imageResizerApplication = imageResizerApplication;
    }

    public void Create(CreateImageCommand command)
    {
        var resizeCommand = new ResizeImageCommand(command.Path, command.ImageStream);
        _imageResizerApplication.Resize(resizeCommand);
    }

    public void Remove(string path)
    {
        File.Delete(path);
    }
}