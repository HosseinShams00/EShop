﻿using Microsoft.Extensions.DependencyInjection;
using EShopQuery.Contracts.Admin.DiscountManager;
using EShopQuery.Query.Admin.DiscountManager;
using EShopQuery.Contracts.Admin.InventoryManager;
using EShopQuery.Query.Admin.InventoryManager;
using EShopQuery.Contracts.Admin.ProductCategory;
using EShopQuery.Query.Admin.ProductCategory;
using EShopQuery.Contracts.Admin.Product;
using EShopQuery.Query.Admin.Product;

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

    }
}
