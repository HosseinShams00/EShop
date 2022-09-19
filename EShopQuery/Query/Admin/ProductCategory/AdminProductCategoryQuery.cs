using EShopQuery.Contracts.Admin.ProductCategory;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;
using ShopManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace EShopQuery.Query.Admin.ProductCategory;

public class AdminProductCategoryQuery : IAdminProductCategoryQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public AdminProductCategoryQuery(ShopManagerEFCoreDbContext context)
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

    public List<ProductCategoryViewModel> GetViewModels()
    {
        return Context.ProductCategories.Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            Name = x.Name,
            CreationTime = x.CreationTime.ToString(),
            IsRemoved = x.IsRemoved,
            Description = x.Description,

        }).ToList();
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

        if (string.IsNullOrWhiteSpace(productCategorySearchModel.Name) == false)
            query = query.Where(x => x.Name.Contains(productCategorySearchModel.Name));

        if (productCategorySearchModel.IsRemoved == false)
            query = query.Where(q => q.IsRemoved == false);

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}
