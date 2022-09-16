using BaseFramwork.Application.Exceptions;
using BaseFramwork.Repository;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using DiscountManager.Domain.ProductCustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using System.Linq.Expressions;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class ProductCustomerDiscountRepository : BaseRepository<long, ProductCustomerDiscount>, IProductCustomerDiscountRepository
{
    private readonly DiscountManagerEFCoreDbContext Context;
    private readonly ShopManagerEFCoreDbContext _ShopManagerEFCoreDbContext;

    public ProductCustomerDiscountRepository(DiscountManagerEFCoreDbContext context, ShopManagerEFCoreDbContext shopManagerEFCoreDbContext) : base(context)
    {
        Context = context;
        _ShopManagerEFCoreDbContext = shopManagerEFCoreDbContext;
    }

    public long GetCustomerDiscountId(long productId)
    {
        var productCustomer = Context.ProductCustomerDiscounts.AsNoTracking().FirstOrDefault(x => x.ProductId == productId);
        if (productCustomer == null)
            return 0;

        return productCustomer.CustomerDiscountId;
    }

    public EditProdcutCustomerCommand? GetEditCommand(long productId)
    {
        return Context.ProductCustomerDiscounts.AsNoTracking()
            .Select(x => new EditProdcutCustomerCommand()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                CustomerDiscountId = x.CustomerDiscountId,

            }).FirstOrDefault(x => x.ProductId == productId);
    }

    public List<ProductCustomerDiscountViewModel> GetProductsViewModels(long customerDiscountId)
    {
        List<ProductCustomerDiscountViewModel> result = new();
        var productCustomers = Context.ProductCustomerDiscounts.Where(x => x.CustomerDiscountId == customerDiscountId)
            .AsNoTracking().ToList();

        foreach (var productCustomer in productCustomers)
        {
            var query = _ShopManagerEFCoreDbContext.Products.Where(x => x.Id == productCustomer.ProductId)
                .AsNoTracking().Select(x => new ProductCustomerDiscountViewModel()
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

    public void RemoveBy(long productId)
    {
        var product = Context.ProductCustomerDiscounts.FirstOrDefault(x => x.ProductId == productId);

        if (product == null)
            throw new EntityNotFoundException();

        Context.ProductCustomerDiscounts.Remove(product);
        Context.SaveChanges();
    }

}