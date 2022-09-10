using EShopQuery.Contracts.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class ProductCategoryViewComponent : ViewComponent
{
    private readonly IProductCategoryQuery ProductCategoryQuery;

    public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
    {
        ProductCategoryQuery = productCategoryQuery;
    }

    public IViewComponentResult Invoke()
    {
        var productCategory = ProductCategoryQuery.GetViewModels();
        return View(productCategory);
    }

}