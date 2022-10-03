namespace CommentManager.Application.Contract.ProductCommentAgg.Command;

public class CreateProductCommentCommand
{
    public string Message { get; set; }
    public long UserId { get; set; }
    public long? AdminId { get; set; }
    public long? ParentCommentId { get; set; }
    public long ProductId { get; set; }
}