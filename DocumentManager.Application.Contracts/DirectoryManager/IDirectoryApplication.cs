namespace DocumentManager.Application.Contracts.DirectoryManager;

public interface IDirectoryApplication
{
    void Create(string path);
    string Create(string baseDirectory, params string[] path);
    void Delete(string path);
    void Delete(string path, bool recursive);
}
