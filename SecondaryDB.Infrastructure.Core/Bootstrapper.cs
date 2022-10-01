using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecondaryDB.Domain;
using SecondaryDB.Infrastructure.EFCore;
using SecondaryDB.Infrastructure.EFCore.Repository;

namespace SecondaryDB.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SecondaryDBEfCoreContext>(x => x.UseSqlServer(connectionString));

        services.AddTransient<IProductCategoryQueryRepository, ProductCategoryQueryRepository>();
        services.AddTransient<IProductQueryRepository, ProductQueryRepository>();
        services.AddTransient<IProductPictureQueryRepository, ProductPictureQueryRepository>();
        services.AddTransient<ICustomerDiscountQueryRepository, CustomerDiscountQueryRepository>();
        services.AddTransient<IInventoryQueryRepository, InventoryQueryRepository>();
        services.AddTransient<ISliderQueryRepository, SliderQueryRepository>();

    }
}
