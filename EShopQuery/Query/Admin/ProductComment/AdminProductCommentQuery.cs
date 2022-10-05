using CommentManager.Application.Contract.ProductCommentAgg.Command;
using EShopQuery.Contracts.Admin.ProductComment;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.Admin.ProductComment;

public class AdminProductCommentQuery : IAdminProductCommentQuery
{
    private readonly SecondaryDBEfCoreContext _secondaryDbEfCoreContext;

    public AdminProductCommentQuery(SecondaryDBEfCoreContext secondaryDbEfCoreContext)
    {
        _secondaryDbEfCoreContext = secondaryDbEfCoreContext;
    }
    public EditProductCommentStatusCommand? GetStatusCommand(long id)
    {
        return _secondaryDbEfCoreContext.ProductCommentQueries
            .Where(x => x.Id == id)
            .Select(x => new EditProductCommentStatusCommand()
            {
                AdminId = 0,
                CommentId = x.Id
            })
            .FirstOrDefault();
    }

    public List<AdminProductCommentQueryModel> GetViewModels()
    {
        return _secondaryDbEfCoreContext.ProductCommentQueries
            .Select(x => new AdminProductCommentQueryModel()
            {
                Id = x.Id,
                CreationDateTime = x.CreationDateTime,
                IsConfirmed = x.IsConfirmed,
                Message = x.Message,
                ProductName = x.ProductQuery.Name,
                UserId = x.UserId

            })
            .ToList();
    }
}