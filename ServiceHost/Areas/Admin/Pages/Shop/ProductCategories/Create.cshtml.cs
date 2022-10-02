using System.ComponentModel.DataAnnotations;
using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using ShopManagement.Application.Contract.ProductCategroyAgg;
using ShopManagement.Application.Contract.ProductCategroyAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProductCategory Command { get; set; }
    private readonly IProductCategoryApplication _productCategoryApplication;
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
        _baseDirectory = Path.Combine(hostEnvironment.WebRootPath, "Pictures");
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

        var guid = Helper.CreateImageWithGuidDirectory(_directoryApplication, _imageApplication, _baseDirectory, PictureFile);
        Command.Picture = guid;

        try
        {
            _productCategoryApplication.Create(Command);
        }
        catch (Exception e)
        {
            _directoryApplication.Delete(Path.Combine(_baseDirectory, guid), true);
        }

        return RedirectToPage("./index");
    }
    
}
