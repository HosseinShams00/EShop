using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager.Commands;
namespace ServiceHost;

public class Helper
{
    public static string CreateImageWithGuidDirectory(IDirectoryApplication directoryApplication,
        IImageApplication imageApplication,
        string baseDirectory,
        IFormFile pictureFile)
    {
        string guid = Guid.NewGuid().ToString();
        var path = directoryApplication.Create(baseDirectory, guid);
        var imageCommand = new CreateImageCommand(path, pictureFile.OpenReadStream());
        imageApplication.Create(imageCommand);
        return guid;
    }
}