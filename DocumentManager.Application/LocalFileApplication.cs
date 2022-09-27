using DocumentManager.Application.Contracts.FileManager;
using DocumentManager.Application.Contracts.FileManager.Commands;

namespace DocumentManager.Application;

public class LocalFileApplication : IFileManagerApplication
{
    public void CreateFile(CreateFileCommand command)
    {
        using (var file = File.Create(command.FilePath))
        {
            command.FileStream.CopyTo(file);
        }

    }

    public void RemoveFile(string path)
    {
        File.Delete(path);
    }
}