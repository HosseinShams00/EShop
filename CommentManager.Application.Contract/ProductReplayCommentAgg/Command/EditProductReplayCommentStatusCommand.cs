namespace CommentManager.Application.Contract.ProductReplayCommentAgg.Command;

public class EditProductReplayCommentStatusCommand
{
    public long CommentId { get; set; }
    public long AdminId { get; set; }
}