using DocumentManager.Application;
using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.FileManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using DocumentManager.Application.Contracts.ImageManager.ImageSizeManager;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentManager.Infrastructures;

public class AspBootstrapper
{
    public static void Config(IServiceCollection services)
    {
        services.AddTransient<IDirectoryApplication, LocalDirectoryApplication>();
        services.AddTransient<IFileManagerApplication, LocalFileApplication>();
        services.AddTransient<IImageApplication, ImageApplication>();
        services.AddTransient<IImageResizerApplication, ImageResizerApplication>();
    }
}