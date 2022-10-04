using BaseFramework.Domain.CommentAgg;
using SecondaryDB.Domain.ProductQueryAgg;
using SecondaryDB.Domain.ReplayCommentQueryAgg;

namespace SecondaryDB.Domain.ProductCommentQueryAgg;

public class ProductCommentQuery : ICommentBase
{
    public long Id { get; set; }
    public string Message { get; set; }
    public bool? IsConfirmed { get; set; }
    public long UserId { get; set; }
    public long? AdminId { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime? ConfirmedDateTime { get; set; }
    public long ProductQueryId { get; set; }
    public ProductQuery? ProductQuery { get; set; }
    public List<ProductReplayCommentQuery> ProductReplayCommentQueries { get; set; } = new();

}