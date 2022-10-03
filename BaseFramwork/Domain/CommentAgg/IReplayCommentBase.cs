namespace BaseFramework.Domain.CommentAgg;

public interface IReplayCommentBase
{
    public long Id { get; }
    public long CommentId { get; }
    public string Message { get; }
    public bool? IsConfirmed { get; }
    public long UserId { get; }
    public long? AdminId { get; }
    public DateTime CreationDateTime { get; }
    public DateTime? ConfirmedDateTime { get; }

}