using DocumentManager.Application.Contracts.ImageManager.ImageFileManager.Commands;

namespace DocumentManager.Application.Contracts.ImageManager.ImageFileManager;

public interface IImageApplication
{
    void Create(CreateImageCommand command);
    void Remove(string path);
}
