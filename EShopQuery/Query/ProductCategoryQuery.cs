﻿using EShopQuery.Contracts.ProductCategories;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query;

public class ProductCategoryQuery : IProductCategoryQuery
{
    private readonly EFCoreDbContext Context;

    public ProductCategoryQuery(EFCoreDbContext context)
    {
        Context = context;
    }
    public List<ProductCategoriesQueryViewModels> GetViewModels()
    {
        return Context.ProductCategories.AsNoTracking().Where(q => q.IsRemoved == false)
            .Select(x => new ProductCategoriesQueryViewModels()
            {
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Slug = x.Slug,

            }).ToList();
    }
}