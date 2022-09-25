using EShopQuery.Contracts.User.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class SearchModel : PageModel
{
    private readonly IUserProductQuery _userProductCategoryQuery;


    public IReadOnlyCollection<UserProductQueryModel> ViewModel;


    public SearchModel(IUserProductQuery userProductCategoryQuery)
    {
        _userProductCategoryQuery = userProductCategoryQuery;
    }

    public void OnGet(string productName)
    {
        ViewModel = _userProductCategoryQuery.Search(productName);
    }
}