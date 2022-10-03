namespace CommentManager.Application.Contract.ProductCommentAgg.Command;

public class EditProductCommentStatusCommand
{
    public long CommentId { get; set; }
    public long AdminId { get; set; }
}