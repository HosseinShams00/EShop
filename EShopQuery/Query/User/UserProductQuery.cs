using EShopQuery.Contracts.User.Product;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.User;

public class UserProductQuery : IUserProductQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public UserProductQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public List<UserProductQueryModel> GetLastProductsQueryModels()
    {
        var userProductQueryModels = _context.ProductQueries
            .Select(q => new UserProductQueryModel()
            {
                Id = q.Id,
                Name = q.Name,
                Picture = q.Picture,
                PictureAlt = q.PictureAlt,
                PictureTitle = q.PictureTitle,
                CategoryName = q.ProductCategoryQuery.Name,
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
            .ToList();

        foreach (var userProductQueryModel in userProductQueryModels)
        {
            ProductHelper.FillPriceWithDiscountValue(userProductQueryModel);
        }

        return userProductQueryModels;
    }

    public List<UserProductQueryModel> Search(string productName)
    {
        var userProductQueryModels = _context.ProductQueries
            .Where(x => x.IsRemoved == false && x.Name.Contains(productName))
            .Select(q => new UserProductQueryModel()
            {
                Id = q.Id,
                Name = q.Name,
                Picture = q.Picture,
                PictureAlt = q.PictureAlt,
                PictureTitle = q.PictureTitle,
                CategoryName = q.ProductCategoryQuery.Name,
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
            .ToList();

        foreach (var userProductQueryModel in userProductQueryModels)
        {
            ProductHelper.FillPriceWithDiscountValue(userProductQueryModel);
        }

        return userProductQueryModels;
    }
}