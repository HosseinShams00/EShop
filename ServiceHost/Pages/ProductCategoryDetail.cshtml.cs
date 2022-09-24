using EShopQuery.Contracts.User.ProductCategories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class ProductCategoryDetailModel : PageModel
{
    private readonly IUserProductCategoryQuery _userProductCategoryQuery;
    public UserProductCategoriesQuery ViewModel; 

    public ProductCategoryDetailModel(IUserProductCategoryQuery userProductCategoryQuery)
    {
        _userProductCategoryQuery = userProductCategoryQuery;
    }

    public void OnGet(long categoryId, string slug)
    {
        ViewModel = _userProductCategoryQuery.GetViewModelWithProduct(categoryId);
    }
}