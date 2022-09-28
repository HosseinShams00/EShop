using System.ComponentModel.DataAnnotations;
using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class CreateModel : PageModel
{
    [BindProperty] public CreateProduct Command { get; set; }

    [Required(ErrorMessage = "برای این بخش باید عکس انتخاب شود")]
    [HaveExtenstion(Extenstion = new string[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "فرمت ورودی صحیح نمیباشد")]
    [MaxFileSize(MaxSizeInMB = 2, ErrorMessage = "حجم فایل بیش از حد مجاز {0} مگابایت است.")]
    [BindProperty] public IFormFile PictureFile { get; set; }


    private readonly IProductApplication _productApplication;
    private readonly IAdminProductCategoryQuery _adminQuery;
    private readonly IDirectoryApplication _directoryApplication;
    private readonly IImageApplication _imageApplication;
    private readonly string _baseDirectory;
    public IReadOnlyCollection<ProductCategoryQueryModel> ProductCategroies { get; set; }


    public CreateModel(IProductApplication productApplication,
        IAdminProductCategoryQuery adminQuery,
        IWebHostEnvironment hostEnvironment,
        IDirectoryApplication directoryApplication,
        IImageApplication imageApplication)
    {
        _productApplication = productApplication;
        _adminQuery = adminQuery;
        _directoryApplication = directoryApplication;
        _imageApplication = imageApplication;
        _baseDirectory = Path.Combine(hostEnvironment.WebRootPath, "Pictures");

    }

    public void OnGet()
    {
        Command = new();
        ProductCategroies = _adminQuery.GetViewModels();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            ProductCategroies = _adminQuery.GetViewModels();
            return Page();
        }

        var guid = Helper.CreateImageWithGuidDirectory(_directoryApplication, _imageApplication, _baseDirectory, PictureFile);
        Command.Picture = guid;

        try
        {
            _productApplication.Create(Command);
        }
        catch (Exception e)
        {
            _directoryApplication.Delete(Path.Combine(_baseDirectory, guid), true);
        }

        return RedirectToPage("./index");
    }

}
