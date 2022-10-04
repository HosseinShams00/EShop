using BaseFramework.Domain.CommentAgg;

namespace SecondaryDB.Domain.ReplayCommentQueryAgg;

public class ReplayCommentQuery : IReplayCommentBase
{

    public long Id { get; set; }
    public long CommentId { get; set; }
    public string Message { get; set; }
    public bool? IsConfirmed { get; set; }
    public long UserId { get; set; }
    public long? AdminId { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime? ConfirmedDateTime { get; set; }

}