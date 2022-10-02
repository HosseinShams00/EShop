using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductCategroyAgg.Command;

public class CreateProductCategory
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا نام دسته بندی را وارد نمایید")]
    [MaxLength(255, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Name { get; set; }

    [Required(ErrorMessage = "لطفا توضیحات محصول را وارد نمایید")]
    [MaxLength(500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(5, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string? Description { get; set; }

    public string? Picture { get; set; }

    [MaxLength(255, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string? PictureAlt { get; set; }

    [MaxLength(255, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string? PictureTitle { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا کلمه کلیدی دسته بندی را وارد نمایید")]
    [MaxLength(80, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Keywords { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا Meta Description دسته بندی را وارد نمایید")]
    [MaxLength(150, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string MetaDescription { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا Slug دسته بندی را وارد نمایید")]
    [MaxLength(300, ErrorMessage = "مقدار وارد شده بیش از حد مجاز میباشد")]
    [MinLength(3, ErrorMessage = "مقدار وارد شده کمتر از حد مجاز میباشد")]
    public string Slug { get; set; }
}
