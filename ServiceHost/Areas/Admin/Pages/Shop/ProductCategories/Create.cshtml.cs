using System.ComponentModel.DataAnnotations;
using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductCategory Command { get; set; }
    private readonly IProductCategoryApplication _productCategoryApplication;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IDirectoryApplication _directoryApplication;
    private readonly IImageApplication _imageApplication;

    private readonly string _baseDirectory;

    [Required(ErrorMessage = "برای این بخش باید عکس انتخاب شود")]
    [HaveExtenstion(Extenstion = new string[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "فرمت ورودی صحیح نمیباشد")]
    [MaxFileSize(MaxSizeInMB = 2, ErrorMessage = "حجم فایل بیش از حد مجاز {0} مگابایت است.")]
    [BindProperty] public IFormFile PictureFile { get; set; }

    public CreateModel(IProductCategoryApplication productCategoryApplication,
        IWebHostEnvironment hostEnvironment,
        IDirectoryApplication directoryApplication,
        IImageApplication imageApplication)
    {
        _productCategoryApplication = productCategoryApplication;
        _hostEnvironment = hostEnvironment;
        _baseDirectory = Path.Combine(_hostEnvironment.WebRootPath, "Pictures");
        _directoryApplication = directoryApplication;
        _imageApplication = imageApplication;
    }

    public void OnGet()
    {
        Command = new();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        var guid = CreateImage();
        Command.Picture = guid;

        try
        {
            _productCategoryApplication.Create(Command);
            return RedirectToPage("./index");
        }
        catch (Exception e)
        {
            _directoryApplication.Delete(Path.Combine(_baseDirectory, guid), true);
            return RedirectToPage("./index");
        }
    }

    private string CreateImage()
    {
        string guid = Guid.NewGuid().ToString();
        var path = _directoryApplication.Create(_baseDirectory, guid);
        var imageCommand = new CreateImageCommand(path, PictureFile.OpenReadStream());
        _imageApplication.Create(imageCommand);
        return guid;
    }
}
