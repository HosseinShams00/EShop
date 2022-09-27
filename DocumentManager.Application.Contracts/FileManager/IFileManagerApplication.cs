using DocumentManager.Application.Contracts.FileManager.Commands;

namespace DocumentManager.Application.Contracts.FileManager;

public interface IFileManagerApplication
{
    void CreateFile(CreateFileCommand command);
    void RemoveFile(string path);
}
