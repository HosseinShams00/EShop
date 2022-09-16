using System.ComponentModel.DataAnnotations;

namespace DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;

public class DefineCustomerDiscount
{
    [Required(ErrorMessage = "این فیلد اجباری میباشد")]
    [MaxLength(100, ErrorMessage = "طول کارکتر باید کمتر از 100 باشد")]
    public string Title { get; set; }

    [MaxLength(100, ErrorMessage = "طول کارکتر باید کمتر از 100 باشد")]
    public string? Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    [Range(1 , 99 , ErrorMessage = "مقدار این فیلد باید بین 1 تا 99 باشد")]
    public int DiscountPercent { get; set; }
}
