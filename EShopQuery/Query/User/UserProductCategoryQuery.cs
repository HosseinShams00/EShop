using DiscountManager.Infrastructure.EFCore;
using EShopQuery.Contracts.User.Product;
using EShopQuery.Contracts.User.ProductCategories;
using InventoryManager.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query.User;

public class UserProductCategoryQuery : IUserProductCategoryQuery
{
    private readonly ShopManagerEFCoreDbContext _context;
    private readonly InventoryEFCoreDbContext _inventoryEfCoreDbContext;
    private readonly DiscountManagerEFCoreDbContext _discountManagerEfCoreDbContext;
    public UserProductCategoryQuery(ShopManagerEFCoreDbContext context,
        InventoryEFCoreDbContext inventoryEfCoreDbContext,
        DiscountManagerEFCoreDbContext discountManagerEfCoreDbContext)
    {
        _context = context;
        _inventoryEfCoreDbContext = inventoryEfCoreDbContext;
        _discountManagerEfCoreDbContext = discountManagerEfCoreDbContext;
    }


    public List<UserProductCategoriesQuery> GetViewModels()
    {
        return _context.ProductCategories
            .Where(q => q.IsRemoved == false)
            .Select(x => new UserProductCategoriesQuery()
            {
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Slug = x.Slug,

            }).ToList();
    }

    public List<UserProductCategoriesQuery> GetViewModelsWithProduct()
    {
        var productCategoriesQueryViewModelsList = _context.ProductCategories
            .Where(q => q.IsRemoved == false)
            .Select(x => new UserProductCategoriesQuery()
            {
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Slug = x.Slug,

            })
            .ToList();

        foreach (var item in productCategoriesQueryViewModelsList)
        {
            item.ProductQueryModels = GetProductQueryModel(item);

        }

        return productCategoriesQueryViewModelsList;

    }

    private List<UserProductQueryModel> GetProductQueryModel(UserProductCategoriesQuery category)
    {
        var userProductQueryModels = _context.Products
            .Where(x => x.ProductCategoryId == category.Id)
            .Select(q => new UserProductQueryModel()
            {
                Id = q.Id,
                Name = q.Name,
                Picture = q.Picture,
                PictureAlt = q.PictureAlt,
                PictureTitle = q.PictureTitle,
                CategoryName = category.Name,
                Slug = q.Slug,

            })
            .OrderByDescending(x => x.Id)
            .Take(8)
            .ToList();

        foreach (var item in userProductQueryModels)
        {
            item.Price = ProductHelper.GetProductPrice(item.Id, _inventoryEfCoreDbContext).ToString("N0");
            item.IntPrice = ProductHelper.GetProductPrice(item.Id, _inventoryEfCoreDbContext);
            item.IsInStock = ProductHelper.ProductIsInStock(item.Id, _inventoryEfCoreDbContext);
            item.DiscountRate = ProductHelper.GetProductDiscountValue(item.Id, _discountManagerEfCoreDbContext);
            item.PriceWithDiscount = ProductHelper.CalculateDiscount(item.IntPrice, item.DiscountRate).ToString("N0");
            item.HasDiscount = item.DiscountRate > 0;

        }

        return userProductQueryModels;
    }



}