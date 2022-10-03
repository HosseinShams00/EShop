using BaseFramework.Application.Exceptions;
using CommentManager.Application.Contract.ProductCommentAgg;
using CommentManager.Application.Contract.ProductCommentAgg.Command;
using CommentManager.Domain.ProductCommentAgg;

namespace CommentManager.Application;

public class ProductCommentApplication : IProductCommentApplication
{
    private readonly IProductCommentRepository _productCommentRepository;

    public ProductCommentApplication(IProductCommentRepository productCommentRepository)
    {
        _productCommentRepository = productCommentRepository;
    }

    public void Create(CreateProductCommentCommand command)
    {
        var entity = new ProductComment(command.Message, command.UserId, command.ProductId, command.ParentCommentId);
        _productCommentRepository.Create(entity);
    }

    public void Confirmed(EditProductCommentStatusCommand command)
    {
        var entity = _productCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Confirm(command.AdminId);
        _productCommentRepository.UpdateEntity(entity);
    }

    public void Deny(EditProductCommentStatusCommand command)
    {
        var entity = _productCommentRepository.GetBy(command.CommentId);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Deny(command.AdminId);
        _productCommentRepository.UpdateEntity(entity);
    }
}