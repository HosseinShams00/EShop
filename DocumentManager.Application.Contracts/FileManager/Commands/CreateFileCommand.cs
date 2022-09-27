namespace DocumentManager.Application.Contracts.FileManager.Commands;

public class CreateFileCommand
{
    public string FilePath { get; private set; }
    public Stream FileStream { get; private set; }

    public CreateFileCommand(string filePath, Stream fileStream)
    {
        FilePath = filePath;
        FileStream = fileStream;
    }

}
