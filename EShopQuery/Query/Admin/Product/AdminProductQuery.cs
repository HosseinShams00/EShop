using EShopQuery.Contracts.Admin.Product;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using BaseFramework.Application.Exceptions;
using EShopQuery.Contracts.Admin.InventoryManager;

namespace EShopQuery.Query.Admin.Product;

public class AdminProductQuery : IAdminProductQuery
{
    private readonly ShopManagerEFCoreDbContext Context;
    private readonly IAdminInventoryQuery _AdminInventoryQury;

    public AdminProductQuery(ShopManagerEFCoreDbContext context, IAdminInventoryQuery adminInventoryQury)
    {
        Context = context;
        _AdminInventoryQury = adminInventoryQury;
    }

    public EditProduct GetDetail(long id)
    {
        var command = Context.Products
            .Select(x => new EditProduct()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDecription = x.ShortDescription,
                Slug = x.Slug,
                ProductCategoryId = x.ProductCategoryId

            }).FirstOrDefault(q => q.Id == id);

        if (command == null)
            throw new EntityNotFoundException();

        return command;

    }

    public List<ProductQueryModel> GetViewModels()
    {
        return Context.Products
            .Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                InventoryId = _AdminInventoryQury.GetInventoryIdWith(x.Id)

            }).ToList();
    }

    public List<ProductQueryModel> Search(ProductSearchModel productSearchModel)
    {
        var query = Context.Products
            .Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                InventoryId = _AdminInventoryQury.GetInventoryIdWith(x.Id)
            });;

        if (string.IsNullOrWhiteSpace(productSearchModel.Name) == false)
            query = query.Where(x => x.Name.Contains(productSearchModel.Name));

        if (productSearchModel.IsRemoved == false)
            query = query.Where(q => q.IsRemoved == false);

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}
