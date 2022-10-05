using EShopQuery.Contracts.User.Product;
using EShopQuery.Contracts.User.ProductComment;
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

    public UserProductQueryModel? GetProductQueryModelFull(long productId)
    {
        var userProductQueryModel = _context.ProductQueries
            .Where(x => x.Id == productId && x.IsRemoved == false)
            .Select(q => new UserProductQueryModel()
            {
                Id = q.Id,
                Name = q.Name,
                Picture = q.Picture,
                PictureAlt = q.PictureAlt,
                PictureTitle = q.PictureTitle,
                CategoryName = q.ProductCategoryQuery.Name,
                CategorySlug = q.ProductCategoryQuery.Slug,
                DiscountRate = (int?)(q.CustomerDiscountQuery.DiscountPercent),
                DiscountExpireDate = (DateTime?)(q.CustomerDiscountQuery.EndDateTime),
                ShortDescription = q.ShortDescription,
                Description = q.Description,
                MetaDescription = q.MetaDescription,
                HasDiscount = q.CustomerDiscountId != null,
                IntPrice = (int?)(q.InventoryQuery.UnitPrice),
                IsInStock = q.InventoryQuery != null && q.InventoryQuery.CurrentCount > 0,
                Price = ((int?)(q.InventoryQuery.UnitPrice)) == null
                    ? ""
                    : q.InventoryQuery.UnitPrice.ToString("N0"),

                UserProductPictureQueryModels = q.ProductPictureQueries.Where(z => z.IsRemoved == false)
                    .OrderByDescending(a => a.Id)
                    .Select(z => new UserProductPictureQueryModel()
                    {
                        Path = z.Path,
                        PictureAlt = z.PictureAlt,
                        PictureTitle = z.PictureTitle,

                    })
                    .ToList(),

                UserProductCommentQueryModels = q.ProductCommentQueries
                    .Where(z => z.IsConfirmed == true)
                    .OrderByDescending(z => z.CreationDateTime)
                    .Select(z => new UserProductCommentQueryModel()
                    {
                        Id = z.Id,
                        ConfirmedDateTime = z.ConfirmedDateTime,
                        Message = z.Message,
                        UserName = "Test Comment",
                        UserProductReplayCommentQueryModels = z.ProductReplayCommentQueries
                            .Where(y => y.IsConfirmed == true)
                            .OrderByDescending(y => y.CreationDateTime)
                            .Select(y => new UserProductReplayCommentQueryModel()
                            {
                                Message = y.Message,
                                UserName = "Test Replay",
                                ConfirmedDateTime = y.ConfirmedDateTime
                            })
                            .ToList()
                    })
                    .ToList()

            })
            .FirstOrDefault();

        if (userProductQueryModel != null)
            ProductHelper.FillPriceWithDiscountValue(userProductQueryModel);

        return userProductQueryModel;

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