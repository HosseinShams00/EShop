using EShopQuery.Contracts.User.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class ProductCategoryWithProductsViewComponent : ViewComponent
{
    private readonly IUserProductCategoryQuery _userProductCategoryQuery;
        
    public ProductCategoryWithProductsViewComponent(IUserProductCategoryQuery userProductCategoryQuery)
    {
        _userProductCategoryQuery = userProductCategoryQuery;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _userProductCategoryQuery.GetViewModelsWithProduct();
        return View(categories);
    }
}