using SecondaryDB.Domain.ProductCommentQueryAgg;

namespace SecondaryDB.Domain.ReplayCommentQueryAgg;

public class ProductReplayCommentQuery : ReplayCommentQuery
{
    public ProductCommentQuery? ProductCommentQuery { get; set; }

}