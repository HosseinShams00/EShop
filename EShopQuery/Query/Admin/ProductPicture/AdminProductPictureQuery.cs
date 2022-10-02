using EShopQuery.Contracts.Admin.ProductPicture;
using BaseFramework.Application.Exceptions;
using SecondaryDB.Infrastructure.EFCore;
using ShopManagement.Application.Contract.ProductPictureAgg.Command;

namespace EShopQuery.Query.Admin.ProductPicture;

public class AdminProductPictureQuery : IAdminProductPictureQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public AdminProductPictureQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public EditProductPicture GetDetail(long id)
    {
        var command = _context.ProductPictureQueries
            .Select(x => new EditProductPicture()
            {
                Id = x.Id,
                Path = x.Path,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId

            })
            .FirstOrDefault(q => q.Id == id);

        if (command == null)
            throw new EntityNotFoundException();

        return command;

    }

    public List<ProductPictureQueryModel> GetViewModels()
    {
        return _context.ProductPictureQueries
            .Select(x => new ProductPictureQueryModel()
            {
                Id = x.Id,
                Path = x.Path,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                ProductName = x.ProductQuery.Name

            }).ToList();
    }
}
