using EShopQuery.Contracts.ProductCategories;
using EShopQuery.Contracts.Slider;
using EShopQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.ProductAgg;
using ShopManagement.Application.ProductCategoryAgg;
using ShopManagement.Application.ProductPictureAgg;
using ShopManagement.Application.SliderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<EFCoreDbContext>(x => x.UseSqlServer(stringConnection));

        #region Product Category

        services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
        services.AddTransient<IProductCategoryValidator, ProductCategoryValidator>();

        #endregion

        #region Product

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductApplication, ProductApplication>();
        services.AddTransient<IProductValidator, ProductValidator>();

        #endregion

        #region Product Picture

        services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
        services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
        services.AddTransient<IProductPictureValidator, ProductPictureValidator>();

        #endregion

        #region Slider

        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<ISliderApplication, SliderApplication>();

        #endregion

        #region Product Category

        services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();

        #endregion

        #region Slider Query

        services.AddTransient<ISliderQuery, SliderQuery>();

        #endregion

    }
}