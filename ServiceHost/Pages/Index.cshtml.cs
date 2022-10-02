using EShopQuery.Contracts.User.ProductCategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class IndexModel : PageModel
{
    private readonly IUserProductCategoryQuery _userProductCategoryQuery;
    public List<UserProductCategoriesQuery> ViewModel { get; set; }


    public IndexModel(IUserProductCategoryQuery productCategoryQuery)
    {
        _userProductCategoryQuery = productCategoryQuery;
    }

    public void OnGet()
    {
        ViewModel = _userProductCategoryQuery.GetViewModelsWithProduct();
    }

}