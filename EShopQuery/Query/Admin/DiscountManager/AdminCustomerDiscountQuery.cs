using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using EShopQuery.Contracts.Admin.DiscountManager;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.Admin.DiscountManager;

public class AdminCustomerDiscountQuery : IAdminCustomerDiscountQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public AdminCustomerDiscountQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public EditCustomerDiscount? GetDetail(long id)
    {
        return _context.CustomerDiscountQueries
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

    public List<CustomerDiscountQueryModel> GetViewModels()
    {
        return _context.CustomerDiscountQueries
            .Select(x => new CustomerDiscountQueryModel()
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

