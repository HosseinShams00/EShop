using EShopQuery.Contracts.User.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class LastProductsViewComponent : ViewComponent
{
    private readonly IUserProductQuery _userProductQuery;
    private IReadOnlyCollection<UserProductQueryModel> _userProductQueryModels;

    public LastProductsViewComponent(IUserProductQuery userProductQuery)
    {
        _userProductQuery = userProductQuery;
    }

    public IViewComponentResult Invoke()
    {
        _userProductQueryModels = _userProductQuery.GetLastProductsQueryModels();

        return View(_userProductQueryModels);
    }
}