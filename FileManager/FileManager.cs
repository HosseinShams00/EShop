namespace FileManager;

public static class FileManager
{
    public static void CreateFile(string path, Stream fileStream)
    {
        using FileStream file = File.Open(path, FileMode.OpenOrCreate);
        fileStream.CopyTo(file);
    }
}