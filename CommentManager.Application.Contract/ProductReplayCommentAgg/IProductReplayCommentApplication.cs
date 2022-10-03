using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;

namespace CommentManager.Application.Contract.ProductReplayCommentAgg;

public interface IProductReplayCommentApplication
{
    void Create(CreateProductReplayCommentCommand command);
    void Confirmed(EditProductReplayCommentStatusCommand command);
    void Deny(EditProductReplayCommentStatusCommand command);
}