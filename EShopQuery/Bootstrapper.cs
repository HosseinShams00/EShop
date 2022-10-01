using Microsoft.Extensions.DependencyInjection;
using EShopQuery.Contracts.Admin.DiscountManager;
using EShopQuery.Query.Admin.DiscountManager;
using EShopQuery.Contracts.Admin.InventoryManager;
using EShopQuery.Query.Admin.InventoryManager;
using EShopQuery.Contracts.Admin.ProductCategory;
using EShopQuery.Query.Admin.ProductCategory;
using EShopQuery.Contracts.Admin.Product;
using EShopQuery.Query.Admin.Product;
using EShopQuery.Contracts.Admin.ProductPicture;
using EShopQuery.Query.Admin.ProductPicture;
using EShopQuery.Contracts.Admin.Slider;
using EShopQuery.Contracts.User.Product;
using EShopQuery.Query.Admin.Slider;
using EShopQuery.Contracts.User.ProductCategories;
using EShopQuery.Query.User;
using EShopQuery.Contracts.Slider;

namespace EShopQuery;

public class Bootstrapper
{
    public static void Config(IServiceCollection services)
    {

        services.AddTransient<IAdminInventoryQuery, AdminInventoryQuery>();
        services.AddTransient<IAdminCustomerDiscountQuery, AdminCustomerDiscountQuery>();
        services.AddTransient<IAdminProductCustomerDiscountQuery, AdminProductCustomerDiscountQuery>();
        services.AddTransient<IAdminProductCategoryQuery, AdminProductCategoryQuery>();
        services.AddTransient<IAdminProductQuery, AdminProductQuery>();
        services.AddTransient<IAdminProductPictureQuery, AdminProductPictureQuery>();
        services.AddTransient<IAdminSliderQuery, AdminSliderQuery>();

        services.AddTransient<IUserProductCategoryQuery, UserProductCategoryQuery>();
        services.AddTransient<IUserProductQuery, UserProductQuery>();
        services.AddTransient<IUserSliderQuery, UserSliderQuery>();

    }
}
