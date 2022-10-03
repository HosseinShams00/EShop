using BaseFramework.Application.Exceptions;
using CommentManager.Application.Contract.ProductReplayCommentAgg;
using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;
using CommentManager.Domain.ReplayCommentAgg;

namespace CommentManager.Application;

public class ProductReplayCommentApplication : IProductReplayCommentApplication
{
    private readonly IProductReplayCommentRepository _productReplayCommentRepository;

    public ProductReplayCommentApplication(IProductReplayCommentRepository productReplayCommentRepository)
    {
        _productReplayCommentRepository = productReplayCommentRepository;
    }
    public void Create(CreateProductReplayCommentCommand command)
    {
        var entity = new ProductReplayComment(command.CommentId, command.Message, command.UserId, command.AdminId);
        _productReplayCommentRepository.Create(entity);
    }

    public void Confirmed(EditProductReplayCommentStatusCommand command)
    {
        var entity = _productReplayCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Confirm(command.AdminId);
        _productReplayCommentRepository.UpdateEntity(entity);
    }

    public void Deny(EditProductReplayCommentStatusCommand command)
    {
        var entity = _productReplayCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Deny(command.AdminId);
        _productReplayCommentRepository.UpdateEntity(entity);
    }
}