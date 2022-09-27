using DocumentManager.Application.Contracts.ImageManager.ImageSizeManager.Command;

namespace DocumentManager.Application.Contracts.ImageManager.ImageSizeManager;

public interface IImageResizerApplication
{
    void Resize(ResizeImageCommand command);
}