using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using EShopQuery.Contracts.Admin.DiscountManager;
using DiscountManager.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace EShopQuery.Query.Admin.DiscountManager;

public class AdminCustomerDiscountQuery : IAdminCustomerDiscountQuery
{
    private readonly DiscountManagerEFCoreDbContext Context;

    public AdminCustomerDiscountQuery(DiscountManagerEFCoreDbContext context)
    {
        Context = context;
    }

    public EditCustomerDiscount? GetDetail(long id)
    {
        return Context.CustomerDiscounts.AsNoTracking()
            .Select(x => new EditCustomerDiscount()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                EndDateTime = x.EndDateTime,
                StartDateTime = x.StartDateTime,
                DiscountPercent = x.DiscountPercent

            }).FirstOrDefault(z => z.Id == id);
    }

    public List<CustomerDiscountViewModel> GetViewModels()
    {
        return Context.CustomerDiscounts.AsNoTracking()
            .Select(x => new CustomerDiscountViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                EndDateTime = x.EndDateTime,
                StartDateTime = x.StartDateTime,
                CreationDateTime = x.CreationTime,
                IsRemoved = x.IsRemoved,
                DiscountPercent = x.DiscountPercent

            }).ToList();
    }
}

