using EShopQuery.Contracts.User.ProductCategories;
using EShopQuery.Query.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
using ShopManagement.Application.Contract.ProductCategroyAgg;
using ShopManagement.Application.Contract.ProductPictureAgg;
using ShopManagement.Application.Contract.ProductAgg;
using ShopManagement.Application.Contract.SliderAgg;
using EShopQuery.Contracts.User.Slider;

namespace ShopManagement.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<ShopManagerEFCoreDbContext>(x => x.UseSqlServer(stringConnection));

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

        services.AddTransient<IUserProductCategoryQuery, UserProductCategoryQuery>();

        #endregion

        #region Slider Query

        services.AddTransient<IUserSliderQuery, UserSliderQuery>();

        #endregion

    }
}