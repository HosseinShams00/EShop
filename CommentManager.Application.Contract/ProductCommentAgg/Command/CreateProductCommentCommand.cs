using System.ComponentModel.DataAnnotations;

namespace CommentManager.Application.Contract.ProductCommentAgg.Command;

public class CreateProductCommentCommand
{
    [MaxLength(250 , ErrorMessage = "طول کامنت بیش از حد مجاز است")]
    public string Message { get; set; }
    public long UserId { get; set; }
    public long? AdminId { get; set; }
    public long ProductId { get; set; }
}