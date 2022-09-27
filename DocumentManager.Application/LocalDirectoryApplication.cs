using DocumentManager.Application.Contracts.DirectoryManager;

namespace DocumentManager.Application;

public class LocalDirectoryApplication : IDirectoryApplication
{
    public void Create(string path)
    {
        if (Directory.Exists(path) == false)
            Directory.CreateDirectory(path);
    }

    public string Create(string baseDirectory, params string[] segments)
    {
        CreateDirectoryIfNotExist(baseDirectory);

        string res = baseDirectory;

        foreach (var segment in segments)
        {
            res = Path.Combine(res, segment);
            CreateDirectoryIfNotExist(res);
        }

        return res;
    }

    public void Delete(string path)
    {
        Directory.Delete(path, false);
    }

    public void Delete(string path, bool recursive)
    {
        Directory.Delete(path, true);

    }

    private void CreateDirectoryIfNotExist(string baseDirectory)
    {
        if (Directory.Exists(baseDirectory) == false)
            Directory.CreateDirectory(baseDirectory);
    }
}