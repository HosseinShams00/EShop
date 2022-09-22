using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using DiscountManager.Infrastructure.EFCore;
using EShopQuery.Contracts.Admin.DiscountManager;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query.Admin.DiscountManager;

public class AdminProductCustomerDiscountQuery : IAdminProductCustomerDiscountQuery
{
    private readonly DiscountManagerEFCoreDbContext Context;
    private readonly ShopManagerEFCoreDbContext _ShopManagerEFCoreDbContext;

    public AdminProductCustomerDiscountQuery(DiscountManagerEFCoreDbContext context, ShopManagerEFCoreDbContext shopManagerEFCoreDbContext)
    {
        Context = context;
        _ShopManagerEFCoreDbContext = shopManagerEFCoreDbContext;
    }

    public EditProdcutCustomerCommand? GetEditCommand(long productId)
    {
        return Context.ProductCustomerDiscounts
            .Select(x => new EditProdcutCustomerCommand()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                CustomerDiscountId = x.CustomerDiscountId,

            }).FirstOrDefault(x => x.ProductId == productId);
    }

    public List<ProductCustomerDiscountQueryModel> GetProductsViewModels(long customerDiscountId)
    {
        List<ProductCustomerDiscountQueryModel> result = new();

        var productCustomers = Context.ProductCustomerDiscounts
            .Where(x => x.CustomerDiscountId == customerDiscountId)
            .AsNoTracking()
            .ToList();

        foreach (var productCustomer in productCustomers)
        {
            var query = _ShopManagerEFCoreDbContext.Products
                .Where(x => x.Id == productCustomer.ProductId)
                .Select(x => new ProductCustomerDiscountQueryModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PicturePath = x.Picture
                }).FirstOrDefault();

            if (query != null)
                result.Add(query);
        }

        return result;
    }

}
