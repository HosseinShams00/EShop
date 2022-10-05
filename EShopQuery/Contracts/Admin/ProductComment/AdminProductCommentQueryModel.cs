namespace EShopQuery.Contracts.Admin.ProductComment;

public class AdminProductCommentQueryModel
{
    public long Id { get; set; }
    public string Message { get; set; }
    public bool? IsConfirmed { get; set; }
    public long UserId { get; set; }
    public string ProductName { get; set; }
    public DateTime CreationDateTime { get; set; }
}