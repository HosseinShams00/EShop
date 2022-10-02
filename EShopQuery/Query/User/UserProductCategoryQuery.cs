using BaseFramework.Application.Exceptions;
using EShopQuery.Contracts.User.Product;
using EShopQuery.Contracts.User.ProductCategories;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.User;

public class UserProductCategoryQuery : IUserProductCategoryQuery
{

    private readonly SecondaryDBEfCoreContext _secondaryDbEfCoreContext;

    public UserProductCategoryQuery(SecondaryDBEfCoreContext secondaryDbEfCoreContext)
    {
        _secondaryDbEfCoreContext = secondaryDbEfCoreContext;
    }

    public List<UserProductCategoriesQuery> GetViewModels()
    {
        return _secondaryDbEfCoreContext.ProductCategoryQueries
            .Where(q => q.IsRemoved == false)
            .Select(x => new UserProductCategoriesQuery()
            {
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Slug = x.Slug,
                Description = x.Description,

            }).ToList();
    }

    public List<UserProductCategoriesQuery> GetViewModelsWithProduct()
    {
        var userProductCategoriesQueries = GetProductCategoryWithProductsQueryable(null).ToList();
        foreach (var userProductCategoriesQuery in userProductCategoriesQueries)
        {
            ProductHelper.FillPriceWithDiscountValue(userProductCategoriesQuery);
        }

        return userProductCategoriesQueries;
    }

    public UserProductCategoriesQuery GetViewModelWithProduct(long categoryId)
    {
        var productCategoryQueryViewModel = GetProductCategoryWithProductsQueryable(categoryId)
            .FirstOrDefault();

        ProductHelper.FillPriceWithDiscountValue(productCategoryQueryViewModel);

        if (productCategoryQueryViewModel == null)
            throw new EntityNotFoundException();

        return productCategoryQueryViewModel;
    }
    
    private IQueryable<UserProductCategoriesQuery> GetProductCategoryWithProductsQueryable(long? categoryId)
    {
        var query = _secondaryDbEfCoreContext.ProductCategoryQueries
            .Where(q => q.IsRemoved == false);

        if (categoryId != null)
        {
            query = query.Where(q => q.Id == categoryId);
        }

        return query.Select(x => new UserProductCategoriesQuery()
        {
            Id = x.Id,
            Name = x.Name,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Picture = x.Picture,
            Slug = x.Slug,
            Description = x.Description,
            ProductQueryModels = x.Products.Select(q => new UserProductQueryModel()
            {
                Id = q.Id,
                Name = q.Name,
                Picture = q.Picture,
                PictureAlt = q.PictureAlt,
                PictureTitle = q.PictureTitle,
                CategoryName = x.Name,
                Slug = q.Slug,
                DiscountRate = (int?)(q.CustomerDiscountQuery.DiscountPercent),
                DiscountExpireDate = (DateTime?)(q.CustomerDiscountQuery.EndDateTime),
                HasDiscount = q.CustomerDiscountId != null,
                IntPrice = (int?)(q.InventoryQuery.UnitPrice),
                IsInStock = q.InventoryQuery != null && q.InventoryQuery.CurrentCount > 0,
                Price = ((int?)(q.InventoryQuery.UnitPrice)) == null
                        ? ""
                        : q.InventoryQuery.UnitPrice.ToString("N0"),

            })
                .OrderByDescending(z => z.Id)
                .Take(8)
                .ToList()
        });
    }
}