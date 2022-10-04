namespace EShopQuery.Contracts.User.ProductComment;

public class UserProductCommentQueryModel
{
    public long Id { get; set; }
    public string Message { get; set; }
    public string UserName { get; set; }
    public DateTime ConfirmedDateTime { get; set; }
    public IReadOnlyCollection<UserProductReplayCommentQueryModel> UserProductReplayCommentQueryModels { get; set; }
}