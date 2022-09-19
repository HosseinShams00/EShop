using Microsoft.Extensions.DependencyInjection;
using EShopQuery.Contracts.Admin.DiscountManager;
using EShopQuery.Query.Admin.DiscountManager;
using EShopQuery.Contracts.Admin.InventoryManager;
using EShopQuery.Query.Admin.InventoryManager;

namespace EShopQuery;

public class Bootstrapper
{
    public static void Config(IServiceCollection services)
    {
        services.AddTransient<IAdminInventoryQuery, AdminInventoryQuery>();
        services.AddTransient<IAdminCustomerDiscountQuery, AdminCustomerDiscountQuery>();
        services.AddTransient<IAdminProductCustomerDiscountQuery, AdminProductCustomerDiscountQuery>();

    }
}
