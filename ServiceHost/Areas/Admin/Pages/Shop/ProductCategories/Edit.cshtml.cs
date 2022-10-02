using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using BaseFramework.Application.Exceptions;
using ShopManagement.Application.Contract.ProductCategroyAgg.Command;
using ShopManagement.Application.Contract.ProductCategroyAgg;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories;

public class EditModel : PageModel
{

    [BindProperty] public EditProductCategory Command { get; set; }

    [HaveExtenstion(Extenstion = new string[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "فرمت ورودی صحیح نمیباشد")]
    [MaxFileSize(MaxSizeInMB = 2, ErrorMessage = "حجم فایل بیش از حد مجاز {0} مگابایت است.")]
    [BindProperty] public IFormFile? PictureFile { get; set; }

    private readonly IProductCategoryApplication _productCategoryApplication;
    private readonly IAdminProductCategoryQuery _adminQuery;
    private readonly IDirectoryApplication _directoryApplication;
    private readonly IImageApplication _imageApplication;
    private readonly string _baseDirectory;

    public EditModel(IProductCategoryApplication productCategoryApplication,
        IAdminProductCategoryQuery adminQuery,
        IWebHostEnvironment hostEnvironment,
        IDirectoryApplication directoryApplication,
        IImageApplication imageApplication)
    {
        _productCategoryApplication = productCategoryApplication;
        _adminQuery = adminQuery;
        _directoryApplication = directoryApplication;
        _imageApplication = imageApplication;
        _baseDirectory = Path.Combine(hostEnvironment.WebRootPath, "Pictures");

    }


    public void OnGet(long id)
    {
        Command = _adminQuery.GetDetail(id) ?? throw new EntityNotFoundException();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        string? guid = null, lastImagePath = null;

        if (PictureFile != null)
        {
            lastImagePath = Command.Picture;
            guid = Helper.CreateImageWithGuidDirectory(_directoryApplication, _imageApplication, _baseDirectory, PictureFile);
            Command.Picture = guid;
        }

        try
        {
            _productCategoryApplication.Update(Command);
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
