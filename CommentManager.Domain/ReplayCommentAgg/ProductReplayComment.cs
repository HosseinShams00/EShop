namespace CommentManager.Domain.ReplayCommentAgg;

public class ProductReplayComment : ReplayComment
{
    public ProductReplayComment(long commentId, string message, long userId, long? adminId) : base(commentId, message, userId, adminId)
    {
    }

    public void Confirm(long adminId)
    {
        IsConfirmed = true;
        ConfirmedDateTime = DateTime.Now;
        AdminId = adminId;
    }

    public void Deny(long adminId)
    {
        IsConfirmed = false;
        ConfirmedDateTime = DateTime.Now;
        AdminId = adminId;
    }
}