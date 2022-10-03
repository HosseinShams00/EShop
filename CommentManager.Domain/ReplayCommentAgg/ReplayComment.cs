using BaseFramework.Domain.CommentAgg;

namespace CommentManager.Domain.ReplayCommentAgg;

public class ReplayComment : IReplayCommentBase
{

    public long Id { get; protected set; }
    public long CommentId { get; protected set; }
    public string Message { get; protected set; }
    public bool? IsConfirmed { get; protected set; }
    public long UserId { get; protected set; }
    public long? AdminId { get; protected set; }
    public DateTime CreationDateTime { get; protected set; }
    public DateTime? ConfirmedDateTime { get; protected set; }


    public ReplayComment(long commentId, string message, long userId, long? adminId)
    {
        CommentId = commentId;
        Message = message;
        UserId = userId;
        AdminId = adminId;
    }
}