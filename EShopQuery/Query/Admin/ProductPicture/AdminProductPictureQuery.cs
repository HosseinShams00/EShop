using EShopQuery.Contracts.Admin.ProductPicture;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;
using ShopManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using BaseFramework.Application.Exceptions;

namespace EShopQuery.Query.Admin.ProductPicture;

public class AdminProductPictureQuery : IAdminProductPictureQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public AdminProductPictureQuery(ShopManagerEFCoreDbContext context)
    {
        this.Context = context;
    }

    public EditProductPicture GetDetail(long id)
    {
        var command = Context.ProductPictures
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
        return Context.ProductPictures
            .Include(x => x.Product)
            .Select(x => new ProductPictureQueryModel()
            {
                Id = x.Id,
                Path = x.Path,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                ProductName = x.Product.Name

            }).ToList();
    }
}
