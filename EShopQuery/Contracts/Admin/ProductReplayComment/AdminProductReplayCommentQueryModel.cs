namespace EShopQuery.Contracts.Admin.ProductReplayComment;

public class AdminProductReplayCommentQueryModel
{
    public long Id { get; set; }
    public string CommentMessage { get; set; }
    public string ReplayMessage { get; set; }
    public bool? IsConfirmed { get; set; }
    public long UserId { get; set; }
    public DateTime CreationDateTime { get; set; }
}