using DiscountManager.Infrastructure.EFCore;
using EShopQuery.Contracts.User.Product;
using InventoryManager.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query.User;

public class UserProductQuery : IUserProductQuery
{

    private readonly ShopManagerEFCoreDbContext _shopManagerEfCoreDbContext;
    private readonly InventoryEFCoreDbContext _inventoryEfCoreDbContext;
    private readonly DiscountManagerEFCoreDbContext _discountManagerEfCoreDbContext;

    public UserProductQuery(ShopManagerEFCoreDbContext shopManagerEfCoreDbContext,
        InventoryEFCoreDbContext inventoryEfCoreDbContext,
        DiscountManagerEFCoreDbContext discountManagerEfCoreDbContext)
    {
        _shopManagerEfCoreDbContext = shopManagerEfCoreDbContext;
        _inventoryEfCoreDbContext = inventoryEfCoreDbContext;
        _discountManagerEfCoreDbContext = discountManagerEfCoreDbContext;
    }

    public List<UserProductQueryModel> GetLastProductsQueryModels()
    {
        var userProductQueryModels = _shopManagerEfCoreDbContext.Products
            .Select(x => new UserProductQueryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CategoryName = x.ProductCategory.Name,
                Slug = x.Slug,
            })
            .Take(8)
            .OrderByDescending(x => x.Id)
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