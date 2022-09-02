using BaseFramwork.Repository;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constracts.ProductCategroy;
using ShopManagement.Application.Constracts.ProductCategroy.Command;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductCategoryRepository : BaseRepository<long, ProductCategory>, IProductCategoryRepository
{
    private readonly EFCoreDbContext Context;

    public ProductCategoryRepository(EFCoreDbContext context) : base(context)
    {
        Context = context;
    }

    public EditProductCategory? GetDetail(long id)
    {
        return Context.ProductCategories.Select(x => new EditProductCategory()
        {
            Id = x.Id,
            Description = x.Description,
            Name = x.Name,
            Keywords = x.Keywords,
            MetaDescription = x.MetaDescription,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Slug = x.Slug
        }).FirstOrDefault(x => x.Id == id);
    }
    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel)
    {
        var query = Context.ProductCategories.Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            Name = x.Name,
            CreationTime = x.CreationTime.ToString(),
            IsRemoved = x.IsRemoved,
            Description = x.Description,

        });

        if (!string.IsNullOrWhiteSpace(productCategorySearchModel.Name))
            query = query.Where(x => x.Name.Contains(productCategorySearchModel.Name));

        if (productCategorySearchModel.IsRemoved == false)
            query = query.Where(q => q.IsRemoved == false);

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}
