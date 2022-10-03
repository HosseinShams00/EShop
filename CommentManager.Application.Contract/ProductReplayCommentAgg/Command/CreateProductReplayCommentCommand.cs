namespace CommentManager.Application.Contract.ProductReplayCommentAgg.Command;

public class CreateProductReplayCommentCommand
{
    public string Message { get; set; }
    public long CommentId { get; set; }
    public long UserId { get; set; }
    public long? AdminId { get; set; }
    public long? ParentCommentId { get; set; }

}