using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.SliderAgg.Command;

public class CreateSlider
{
    [MaxLength(200, ErrorMessage = "طول متن شما نباید بیشتر از 200 کارکتر باشد")]
    public string? PicturePath { get; set; }

    [MaxLength(100, ErrorMessage = "طول متن شما نباید بیشتر از 100 کارکتر باشد")]

    public string? PictureAlt { get; set; }

    [MaxLength(150, ErrorMessage = "طول متن شما نباید بیشتر از 150 کارکتر باشد")]
    public string? PictureTitle { get; set; }

    [MaxLength(150, ErrorMessage = "طول متن شما نباید بیشتر از 150 کارکتر باشد")]
    public string? Heading { get; set; }

    [MaxLength(100, ErrorMessage = "طول متن شما نباید بیشتر از 100 کارکتر باشد")]
    public string? Title { get; set; }

    [MaxLength(100, ErrorMessage = "طول متن شما نباید بیشتر از 100 کارکتر باشد")]
    public string? BodyText { get; set; }

    [Required(ErrorMessage = "لطفا متن دکمه را وارد کنید")]
    [MaxLength(20, ErrorMessage = "طول متن شما نباید بیشتر از 20 کارکتر باشد")]
    public string ButtonText { get; set; }

    [Required(ErrorMessage = "لطفا لینک اسلایدر را وارد کنید")]
    [MaxLength(150, ErrorMessage = "طول متن شما نباید بیشتر از 150 کارکتر باشد")]
    public string RedirectUrl { get; set; }
}