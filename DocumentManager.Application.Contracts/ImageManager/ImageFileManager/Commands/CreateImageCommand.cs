namespace DocumentManager.Application.Contracts.ImageManager.ImageFileManager.Commands;

public class CreateImageCommand
{

    public string Path { get; private set; }
    public Stream ImageStream { get; private set; }

    public CreateImageCommand(string path, Stream imageStream)
    {
        Path = path;
        ImageStream = imageStream;
    }

}