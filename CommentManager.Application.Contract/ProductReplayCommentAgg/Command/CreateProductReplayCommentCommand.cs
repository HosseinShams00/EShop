using System.ComponentModel.DataAnnotations;

namespace CommentManager.Application.Contract.ProductReplayCommentAgg.Command;

public class CreateProductReplayCommentCommand
{
    [MaxLength(250, ErrorMessage = "طول کامنت بیش از حد مجاز است")]
    public string Message { get; set; }
    public long CommentId { get; set; }
    public long UserId { get; set; }
    public long? AdminId { get; set; }
    public long? ParentCommentId { get; set; }

}