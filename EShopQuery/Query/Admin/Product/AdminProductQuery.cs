using EShopQuery.Contracts.Admin.Product;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using BaseFramwork.Application.Exceptions;

namespace EShopQuery.Query.Admin.Product;

public class AdminProductQuery : IAdminProductQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public AdminProductQuery(ShopManagerEFCoreDbContext context)
    {
        Context = context;
    }

    public EditProduct GetDetail(long id)
    {
        var command = Context.Products.AsNoTracking()
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
                ShortDecription = x.ShortDecription,
                Slug = x.Slug,
                ProductCategoryId = x.ProductCategoryId

            }).FirstOrDefault(q => q.Id == id);

        if (command == null)
            throw new EntityNotFoundException();

        return command;

    }

    public List<ProductViewModel> GetViewModels()
    {
        return Context.Products
            .Select(x => new ProductViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,

            }).ToList();
    }

    public List<ProductViewModel> Search(ProductSearchModel productSearchModel)
    {
        var query = Context.Products
            .Select(x => new ProductViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,

            });

        if (string.IsNullOrWhiteSpace(productSearchModel.Name) == false)
            query = query.Where(x => x.Name.Contains(productSearchModel.Name));

        if (productSearchModel.IsRemoved == false)
            query = query.Where(q => q.IsRemoved == false);

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}
