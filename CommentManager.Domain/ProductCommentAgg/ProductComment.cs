using BaseFramework.Domain.CommentAgg;
using CommentManager.Domain.ReplayCommentAgg;

namespace CommentManager.Domain.ProductCommentAgg;

public class ProductComment : ICommentBase
{
    public long Id { get; private set; }
    public string Message { get; private set; }
    public bool? IsConfirmed { get; private set; }
    public long UserId { get; private set; }
    public long? AdminId { get; private set; }
    public long ProductId { get; private set; }
    public DateTime CreationDateTime { get; private set; }
    public DateTime? ConfirmedDateTime { get; private set; }
    public IReadOnlyCollection<ProductReplayComment> ProductReplayComments { get; set; }

    public ProductComment(string message, long userId, long productId, long? adminId)
    {
        Message = message;
        UserId = userId;
        ProductId = productId;
        AdminId = adminId;
        CreationDateTime = DateTime.Now;
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