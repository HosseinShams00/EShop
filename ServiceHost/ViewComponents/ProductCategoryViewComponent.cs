﻿using EShopQuery.Contracts.User.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class ProductCategoryViewComponent : ViewComponent
{
    private readonly IUserProductCategoryQuery _userProductCategoryQuery;

    public ProductCategoryViewComponent(IUserProductCategoryQuery userProductCategoryQuery)
    {
        _userProductCategoryQuery = userProductCategoryQuery;
    }

    public IViewComponentResult Invoke()
    {
        var productCategory = _userProductCategoryQuery.GetViewModels();
        return View(productCategory);
    }

}