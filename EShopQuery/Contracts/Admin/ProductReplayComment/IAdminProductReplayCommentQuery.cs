using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;

namespace EShopQuery.Contracts.Admin.ProductReplayComment;

public interface IAdminProductReplayCommentQuery
{
    EditProductReplayCommentStatusCommand? GetStatusCommand(long id);
    List<AdminProductReplayCommentQueryModel> GetViewModels();
}