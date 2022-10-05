using BaseFramework.Application;
using BaseFramework.Application.Exceptions;
using CommentManager.Application.Contract.ProductCommentAgg;
using CommentManager.Application.Contract.ProductCommentAgg.Command;
using CommentManager.Domain.ProductCommentAgg;
using SecondaryDB.Domain.ProductCommentQueryAgg;

namespace CommentManager.Application;

public class ProductCommentApplication : IProductCommentApplication
{
    private readonly IProductCommentRepository _productCommentRepository;
    private readonly IProductCommentQueryRepository _productCommentQueryRepository;

    public ProductCommentApplication(IProductCommentRepository productCommentRepository,
        IProductCommentQueryRepository productCommentQueryRepository)
    {
        _productCommentRepository = productCommentRepository;
        _productCommentQueryRepository = productCommentQueryRepository;
    }

    public void Create(CreateProductCommentCommand command)
    {
        var entity = new ProductComment(command.Message, command.UserId, command.ProductId, command.AdminId);
        _productCommentRepository.Create(entity);

        var query = Convertor.Convert<ProductCommentQuery>(entity);
        query.ProductQueryId = entity.ProductId;
        _productCommentQueryRepository.Create(query);
    }

    public void Confirmed(EditProductCommentStatusCommand command)
    {
        var entity = _productCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Confirm(command.AdminId);
        _productCommentRepository.UpdateEntity(entity);

        var query = _productCommentQueryRepository.GetBy(entity.Id);
        query.IsConfirmed = entity.IsConfirmed;
        _productCommentQueryRepository.UpdateEntity(query);
    }

    public void Deny(EditProductCommentStatusCommand command)
    {
        var entity = _productCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Deny(command.AdminId);
        _productCommentRepository.UpdateEntity(entity);

        var query = _productCommentQueryRepository.GetBy(entity.Id);
        query.IsConfirmed = entity.IsConfirmed;
        _productCommentQueryRepository.UpdateEntity(query);
    }
}