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

            }).ToList();
    }

    public List<UserProductCategoriesQuery> GetViewModelsWithProduct()
    {
        return GetProductCategoryWithProductsQueryable(null).ToList();

    }

    public UserProductCategoriesQuery GetViewModelWithProduct(long categoryId)
    {
        var productCategoryQueryViewModel = GetProductCategoryWithProductsQueryable(categoryId)
            .FirstOrDefault();

        if (productCategoryQueryViewModel == null)
            throw new EntityNotFoundException();

        foreach (var userProductQueryModel in productCategoryQueryViewModel.ProductQueryModels)
        {
            userProductQueryModel.PriceWithDiscount = ProductHelper.CalculateDiscount(userProductQueryModel.IntPrice,
                userProductQueryModel.DiscountRate).ToString("N0");
        }

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
                DiscountRate = q.CustomerDiscountQuery.DiscountPercent,
                DiscountExpireDate = q.CustomerDiscountQuery.EndDateTime,
                HasDiscount = q.CustomerDiscountId != 0,
                IntPrice = q.InventoryQuery.UnitPrice,
                IsInStock = q.InventoryQuery.CurrentCount > 0,
                Price = q.InventoryQuery.UnitPrice.ToString("N0"),

            })
                .OrderByDescending(z => z.Id)
                .Take(8)
                .ToList()
        });
    }
}