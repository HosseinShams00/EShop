using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductPictureAgg.Command;

public class CreateProductPicture
{
    [Required(ErrorMessage = "لطفا آدرس عکس را وارد کنید")]
    [MaxLength(300, ErrorMessage = "طول متن شما نباید بیشتر از 300 کارکتر باشد")]
    public string Path { get; set; }

    [MaxLength(100, ErrorMessage = "طول متن شما نباید بیشتر از 100 کارکتر باشد")]
    public string? PictureAlt { get; set; }


    [MaxLength(100, ErrorMessage = "طول متن شما نباید بیشتر از 100 کارکتر باشد")]
    public string? PictureTitle { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "مقدار وارد شده صحیح نمیباشد")]
    public long ProductId { get; set; }

}