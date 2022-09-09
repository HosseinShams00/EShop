using BaseFramwork.Repository;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductRepository : BaseRepository<long, Product>, IProductRepository
{
    private readonly EFCoreDbContext Context;

    public ProductRepository(EFCoreDbContext context) : base(context)
    {
        Context = context;
    }

    public EditProduct? GetDetail(long id)
    {
        return Context.Products.AsNoTracking().Select(x => new EditProduct()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Keywords = x.Keywords,
            MetaDescription = x.MetaDescription,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            ShortDecription = x.ShortDecription,
            Slug = x.Slug,
            ProductCategoryId = x.ProductCategoryId

        }).FirstOrDefault(q => q.Id == id);

    }

    public List<ProductViewModel> GetViewModels()
    {
        return Context.Products.Select(x => new ProductViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            Name = x.Name,
            CreationTime = x.CreationTime.ToString(),
            IsRemoved = x.IsRemoved,
            
        }).ToList();
    }

    public List<ProductViewModel> Search(ProductSearchModel productSearchModel)
    {
        var query = Context.Products.Select(x => new ProductViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            Name = x.Name,
            CreationTime = x.CreationTime.ToString(),
            IsRemoved = x.IsRemoved,

        });

        if (string.IsNullOrWhiteSpace(productSearchModel.Name) == false)
            query = query.Where(x => x.Name.Contains(productSearchModel.Name));

        if (productSearchModel.IsRemoved == false)
            query = query.Where(q => q.IsRemoved == false);

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}
