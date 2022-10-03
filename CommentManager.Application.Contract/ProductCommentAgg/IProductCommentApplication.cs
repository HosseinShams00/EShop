using CommentManager.Application.Contract.ProductCommentAgg.Command;

namespace CommentManager.Application.Contract.ProductCommentAgg;

public interface IProductCommentApplication
{
    void Create(CreateProductCommentCommand command);
    void Confirmed(EditProductCommentStatusCommand command);
    void Deny(EditProductCommentStatusCommand command);
}