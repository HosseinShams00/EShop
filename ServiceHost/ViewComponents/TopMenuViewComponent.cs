using EShopQuery.Contracts.User.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class TopMenuViewComponent : ViewComponent
{
    private readonly IUserProductCategoryQuery _productCategoryQuery;
    public IReadOnlyCollection<UserProductCategoriesQuery> ViewModel;

    public TopMenuViewComponent(IUserProductCategoryQuery productCategoryQuery)
    {
        _productCategoryQuery = productCategoryQuery;
    }

    public IViewComponentResult Invoke()
    {
        ViewModel = _productCategoryQuery.GetViewModels();
        return View(ViewModel);
    }

}