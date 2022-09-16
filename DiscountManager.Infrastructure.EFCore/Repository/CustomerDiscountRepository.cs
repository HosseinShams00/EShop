using BaseFramwork.Repository;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscountRepository
{
    private readonly DiscountManagerEFCoreDbContext Context;

    public CustomerDiscountRepository(DiscountManagerEFCoreDbContext context) : base(context)
    {
        this.Context = context;
    }

    public EditCustomerDiscount? GetDitail(long id)
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
                CreationDateTime = x.CreationDateTime,
                IsRemoved = x.IsRemoved,
                DiscountPercent = x.DiscountPercent

            }).ToList();
    }
}
