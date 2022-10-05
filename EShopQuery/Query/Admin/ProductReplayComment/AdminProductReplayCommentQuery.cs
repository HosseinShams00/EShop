using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;
using EShopQuery.Contracts.Admin.ProductReplayComment;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.Admin.ProductReplayComment;

public class AdminProductReplayCommentQuery : IAdminProductReplayCommentQuery
{
    private readonly SecondaryDBEfCoreContext _secondaryDbEfCoreContext;

    public AdminProductReplayCommentQuery(SecondaryDBEfCoreContext secondaryDbEfCoreContext)
    {
        _secondaryDbEfCoreContext = secondaryDbEfCoreContext;
    }
    public EditProductReplayCommentStatusCommand? GetStatusCommand(long id)
    {
        return _secondaryDbEfCoreContext.ProductCommentQueries
            .Where(x => x.Id == id)
            .Select(x => new EditProductReplayCommentStatusCommand()
            {
                AdminId = 0,
                CommentId = x.Id,
                
            })
            .FirstOrDefault();
    }

    public List<AdminProductReplayCommentQueryModel> GetViewModels()
    {
        return _secondaryDbEfCoreContext.ProductReplayCommentQueries
            .Select(x => new AdminProductReplayCommentQueryModel()
            {
                Id = x.Id,
                CreationDateTime = x.CreationDateTime,
                IsConfirmed = x.IsConfirmed,
                CommentMessage = x.ProductCommentQuery.Message,
                ReplayMessage = x.Message,
                UserId = x.UserId

            })
            .ToList();
    }
}