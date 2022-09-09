using ShopManagement.Application.Constracts.ProductCategroyAgg;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Constracts.ProductAgg.Command;

public class CreateProduct
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا نام محصول را وارد نمایید")]
    [MaxLength(255, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا توضیحات محصول را وارد نمایید")]
    [MaxLength(2000, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Description { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا توضیحات کوتاه محصول را وارد نمایید")]
    [MaxLength(500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string ShortDecription { get; set; }


    public string? Picture { get; set; }


    [MaxLength(255, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string? PictureAlt { get; set; }


    [MaxLength(500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string? PictureTitle { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا کلمات کلیدی محصول را وارد نمایید")]
    [MaxLength(80, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Keywords { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا Meta Description محصول را وارد نمایید")]
    [MaxLength(150, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string MetaDescription { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا Slug محصول را وارد نمایید")]
    [MaxLength(300, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Slug { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا یک دسته بندی درست محصول را انتخاب نمایید")]
    [Range(1, long.MaxValue, ErrorMessage = "لطفا دسته بندی درست را انتخاب کنید")]
    public long ProductCategoryId { get; set; }

    public List<ProductCategoryViewModel> ProductCategroyies { get; set; } = new();

}