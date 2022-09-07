using BaseFramwork.Repository;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductPictureRepository : BaseRepository<long, ProductPicture>, IProductPictureRepository
{
    private readonly EFCoreDbContext Context;

    public ProductPictureRepository(EFCoreDbContext context) : base(context)
    {
        this.Context = context;
    }

    public EditProductPicture? GetDetail(long id)
    {
        return Context.ProductPictures.AsNoTracking().Select(x => new EditProductPicture()
        {
            Id = x.Id,
            Path = x.Path,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            ProductId = x.ProductId

        }).FirstOrDefault(q => q.Id == id);
    }

    public List<ProductPictureViewModel> GetViewModels()
    {
        return Context.ProductPictures.AsNoTracking().Select(x => new ProductPictureViewModel()
        {
            Id = x.Id,
            Path = x.Path,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            ProductId = x.ProductId

        }).ToList();
    }
}