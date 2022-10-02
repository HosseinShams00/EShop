using DocumentManager.Application.Contracts.DirectoryManager;
using DocumentManager.Application.Contracts.ImageManager.ImageFileManager;
using EShopQuery.Contracts.Admin.Product;
using EShopQuery.Contracts.Admin.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Attributes;
using ShopManagement.Application.Contract.ProductAgg;
using ShopManagement.Application.Contract.ProductAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products;

public class EditModel : PageModel
{
    [BindProperty] public EditProduct Command { get; set; }
    private readonly IProductApplication _productApplication;
    private readonly IAdminProductCategoryQuery _adminQuery;
    private readonly IAdminProductQuery _adminProductQuery;
    private readonly IImageApplication _imageApplication;
    private readonly IDirectoryApplication _directoryApplication;
    private readonly string _baseDirectory;


    [HaveExtenstion(Extenstion = new string[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "فرمت ورودی صحیح نمیباشد")]
    [MaxFileSize(MaxSizeInMB = 2, ErrorMessage = "حجم فایل بیش از حد مجاز {0} مگابایت است.")]
    [BindProperty] public IFormFile? PictureFile { get; set; }

    public IReadOnlyCollection<ProductCategoryQueryModel> ProductCategories { get; set; }

    public EditModel(IProductApplication productApplication,
        IAdminProductCategoryQuery adminQuery,
        IAdminProductQuery adminProductQuery,
        IWebHostEnvironment hostEnvironment,
        IDirectoryApplication directoryApplication,
        IImageApplication imageApplication)
    {
        _productApplication = productApplication;
        _adminQuery = adminQuery;
        _adminProductQuery = adminProductQuery;
        _directoryApplication = directoryApplication;
        _imageApplication = imageApplication;
        _baseDirectory = Path.Combine(hostEnvironment.WebRootPath, "Pictures");
    }

    public void OnGet(long id)
    {

        Command = _adminProductQuery.GetDetail(id);
        ProductCategories = _adminQuery.GetViewModels();

    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            ProductCategories = _adminQuery.GetViewModels();
            return Page();
        }


        string? guid = null, lastImagePath = null;


        if (PictureFile != null)
        {
            lastImagePath = Command.Picture;
            guid = Helper.CreateImageWithGuidDirectory(_directoryApplication, _imageApplication, _baseDirectory, PictureFile);
            Command.Picture = guid;
        }

        try
        {
            _productApplication.Update(Command);

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
