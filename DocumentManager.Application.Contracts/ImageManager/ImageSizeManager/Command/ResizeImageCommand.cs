namespace DocumentManager.Application.Contracts.ImageManager.ImageSizeManager.Command;

public class ResizeImageCommand
{
    public string DirectoryPath { get; private set; }
    public Stream ImageStream { get; private set; }


    public ResizeImageCommand(string directoryPath, Stream imageStream)
    {
        DirectoryPath = directoryPath;
        ImageStream = imageStream;
    }
    
}