using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using EShopQuery.Contracts.Admin.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders;

public class EditModel : PageModel
{
    [BindProperty] public EditSlider Command { get; set; }

    [HaveExtenstion(Extenstion = new string[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "فرمت ورودی صحیح نمیباشد")]
    [MaxFileSize(MaxSizeInMB = 2, ErrorMessage = "حجم فایل بیش از حد مجاز {0} مگابایت است.")]
    [BindProperty] public IFormFile? PictureFile { get; set; }

    private readonly ISliderApplication _application;
    private readonly IAdminSliderQuery _adminSliderQuery;
    private readonly IDirectoryApplication _directoryApplication;
    private readonly IImageApplication _imageApplication;
    private readonly string _baseDirectory;

    public EditModel(ISliderApplication sliderApplication,
        IAdminSliderQuery adminSliderQuery,
        IWebHostEnvironment hostEnvironment,
        IDirectoryApplication directoryApplication,
        IImageApplication imageApplication)
    {
        _application = sliderApplication;
        _adminSliderQuery = adminSliderQuery;
        _directoryApplication = directoryApplication;
        _imageApplication = imageApplication;
        _baseDirectory = Path.Combine(hostEnvironment.WebRootPath, "Pictures");
    }

    public void OnGet(long id)
    {
        Command = _adminSliderQuery.GetDetail(id);
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        string? guid = null, lastImagePath = null;

        if (PictureFile != null)
        {
            lastImagePath = Command.PicturePath;
            guid = Helper.CreateImageWithGuidDirectory(_directoryApplication, _imageApplication, _baseDirectory, PictureFile);
            Command.PicturePath = guid;
        }

        try
        {
            _application.Update(Command);
            if (lastImagePath != null)
                _directoryApplication.Delete(Path.Combine(_baseDirectory, lastImagePath), true);

        }
        catch (Exception e)
        {
            if (guid != null)
            {
                _directoryApplication.Delete(Path.Combine(_baseDirectory, guid), true);
            }
        }

        return RedirectToPage("./index");
    }
}