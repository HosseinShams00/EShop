using System.ComponentModel.DataAnnotations;
using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using ShopManagement.Application.Contract.SliderAgg;
using ShopManagement.Application.Contract.SliderAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class CreateModel : PageModel
{
    private readonly ISliderApplication _application;
    private readonly IDirectoryApplication _directoryApplication;
    private readonly IImageApplication _imageApplication;

    private readonly string _baseDirectory;

    [BindProperty] public CreateSlider Command { get; set; }

    [Required(ErrorMessage = "برای این بخش باید عکس انتخاب شود")]
    [HaveExtenstion(Extenstion = new string[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "فرمت ورودی صحیح نمیباشد")]
    [MaxFileSize(MaxSizeInMB = 2, ErrorMessage = "حجم فایل بیش از حد مجاز {0} مگابایت است.")]
    [BindProperty] public IFormFile PictureFile { get; set; }

    public CreateModel(ISliderApplication sliderApplication,
        IWebHostEnvironment hostEnvironment,
        IDirectoryApplication directoryApplication,
        IImageApplication imageApplication)
    {
        _application = sliderApplication;
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
        Command.PicturePath = guid;

        try
        {
            _application.Create(Command);

        }
        catch (Exception e)
        {
            _directoryApplication.Delete(Path.Combine(_baseDirectory, guid), true);
        }

        return RedirectToPage("./index");
    }

}
