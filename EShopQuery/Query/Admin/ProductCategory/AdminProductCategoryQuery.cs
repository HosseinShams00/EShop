using EShopQuery.Contracts.Admin.ProductCategory;
using SecondaryDB.Infrastructure.EFCore;
using ShopManagement.Application.Contract.ProductCategroyAgg.Command;

namespace EShopQuery.Query.Admin.ProductCategory;

public class AdminProductCategoryQuery : IAdminProductCategoryQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public AdminProductCategoryQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public EditProductCategory? GetDetail(long id)
    {
        return _context.ProductCategoryQueries
            .Select(x => new EditProductCategory()
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
            })
            .FirstOrDefault(x => x.Id == id);

    }

    public List<ProductCategoryQueryModel> GetViewModels()
    {
        return _context.ProductCategoryQueries
            .Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                Description = x.Description,

            }).ToList();
    }

    public List<ProductCategoryQueryModel> Search(ProductCategorySearchModel productCategorySearchModel)
    {
        var query = _context.ProductCategoryQueries
            .Select(x => new ProductCategoryQueryModel
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

        return query.OrderByDescending(x => x.Id).ToList();
    }
}
