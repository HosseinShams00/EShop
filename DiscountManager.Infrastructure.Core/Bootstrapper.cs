using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.CustomerDiscountAgg;
using DiscountManager.Application.ProductCustomerDiscountAgg;
using DiscountManager.Domain.CustomerDiscountAgg;
using DiscountManager.Domain.ProductCustomerDiscountAgg;
using DiscountManager.Infrastructure.EFCore;
using DiscountManager.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManager.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<DiscountManagerEFCoreDbContext>(x => x.UseSqlServer(stringConnection));

        services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
        services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
        services.AddTransient<ICustomerDiscountValidator, CustomerDiscountValidator>();

        services.AddTransient<IProductCustomerDiscountApplication, ProductCustomerDiscountApplication>();
        services.AddTransient<IProductCustomerDiscountRepository, ProductCustomerDiscountRepository>();
        services.AddTransient<IProductCustomerDiscountValidator, ProductCustomerDiscountValidator>();

    }
}