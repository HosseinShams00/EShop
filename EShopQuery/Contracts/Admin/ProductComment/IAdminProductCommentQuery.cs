using CommentManager.Application.Contract.ProductCommentAgg.Command;

namespace EShopQuery.Contracts.Admin.ProductComment;

public interface IAdminProductCommentQuery
{
    EditProductCommentStatusCommand? GetStatusCommand(long id);
    List<AdminProductCommentQueryModel> GetViewModels();
}