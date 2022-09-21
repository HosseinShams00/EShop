using EShopQuery.Contracts.ProductCategories;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query;

public class ProductCategoryQuery : IProductCategoryQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public ProductCategoryQuery(ShopManagerEFCoreDbContext context)
    {
        Context = context;
    }
    public List<ProductCategoriesQueryViewModels> GetViewModels()
    {
        return Context.ProductCategories
            .Where(q => q.IsRemoved == false)
            .Select(x => new ProductCategoriesQueryViewModels()
            {
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Slug = x.Slug,

            }).ToList();
    }
}