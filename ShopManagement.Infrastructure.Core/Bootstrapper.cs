using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.ProductAgg;
using ShopManagement.Application.ProductCategoryAgg;
using ShopManagement.Application.ProductPictureAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<EFCoreDbContext>(x => x.UseSqlServer(stringConnection));

        services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
        services.AddTransient<IProductCategoryValidator, ProductCategoryValidator>();

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductApplication, ProductApplication>();
        services.AddTransient<IProductValidator, ProductValidator>();

        services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
        services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
        services.AddTransient<IProductPictureValidator, ProductPictureValidator>();
    }
}