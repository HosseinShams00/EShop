using BaseFramework.Application;
using BaseFramework.Application.Exceptions;
using CommentManager.Application.Contract.ProductReplayCommentAgg;
using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;
using CommentManager.Domain.ReplayCommentAgg;
using SecondaryDB.Domain.ReplayCommentQueryAgg;

namespace CommentManager.Application;

public class ProductReplayCommentApplication : IProductReplayCommentApplication
{
    private readonly IProductReplayCommentRepository _productReplayCommentRepository;
    private readonly IProductReplayCommentQueryRepository _productReplayCommentQueryRepository;

    public ProductReplayCommentApplication(IProductReplayCommentRepository productReplayCommentRepository,
        IProductReplayCommentQueryRepository productReplayCommentQueryRepository)
    {
        _productReplayCommentRepository = productReplayCommentRepository;
        _productReplayCommentQueryRepository = productReplayCommentQueryRepository;
    }
    public void Create(CreateProductReplayCommentCommand command)
    {
        var entity = new ProductReplayComment(command.CommentId, command.Message, command.UserId, command.AdminId);
        _productReplayCommentRepository.Create(entity);

        var query = Convertor.Convert<ProductReplayCommentQuery>(entity);
        _productReplayCommentQueryRepository.Create(query);
    }

    public void Confirmed(EditProductReplayCommentStatusCommand command)
    {
        var entity = _productReplayCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Confirm(command.AdminId);
        _productReplayCommentRepository.UpdateEntity(entity);

        var query = _productReplayCommentQueryRepository.GetBy(entity.Id);
        query.IsConfirmed = entity.IsConfirmed;
        _productReplayCommentQueryRepository.UpdateEntity(query);
    }

    public void Deny(EditProductReplayCommentStatusCommand command)
    {
        var entity = _productReplayCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Deny(command.AdminId);
        _productReplayCommentRepository.UpdateEntity(entity);

        var query = _productReplayCommentQueryRepository.GetBy(entity.Id);
        query.IsConfirmed = entity.IsConfirmed;
        _productReplayCommentQueryRepository.UpdateEntity(query);
    }
}