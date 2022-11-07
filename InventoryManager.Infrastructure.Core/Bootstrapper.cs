using InventoryManager.Application;
using InventoryManager.Application.Contract.InventoryAgg;
using InventoryManager.Domain.InventoryAgg;
using InventoryManager.Infrastructure.EFCore;
using InventoryManager.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManager.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<InventoryEFCoreDbContext>(x => x.UseSqlServer(stringConnection));

        services.AddTransient<IInventoryApplication, InventoryApplication>();
        services.AddTransient<IInventoryRepository, InventoryRepository>();

    }
}