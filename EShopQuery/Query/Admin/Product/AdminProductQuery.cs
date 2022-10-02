using EShopQuery.Contracts.Admin.Product;
using BaseFramework.Application.Exceptions;
using SecondaryDB.Infrastructure.EFCore;
using ShopManagement.Application.Contract.ProductAgg.Command;

namespace EShopQuery.Query.Admin.Product;

public class AdminProductQuery : IAdminProductQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public AdminProductQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public EditProduct GetDetail(long id)
    {
        var command = _context.ProductQueries
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
        return _context.ProductQueries
            .Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                InventoryId = x.InventoryQuery.Id

            }).ToList();
    }

    public List<ProductQueryModel> Search(ProductSearchModel productSearchModel)
    {
        var query = _context.ProductQueries
            .Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                InventoryId = x.InventoryQuery.Id
            });

        if (string.IsNullOrWhiteSpace(productSearchModel.Name) == false)
            query = query.Where(x => x.Name.Contains(productSearchModel.Name));

        if (productSearchModel.IsRemoved == false)
            query = query.Where(q => q.IsRemoved == false);

        return query.OrderByDescending(x => x.Id).ToList();
    }
}
