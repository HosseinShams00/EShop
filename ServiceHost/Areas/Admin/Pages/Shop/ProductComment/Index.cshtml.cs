using CommentManager.Application.Contract.ProductCommentAgg;
using CommentManager.Application.Contract.ProductCommentAgg.Command;
using EShopQuery.Contracts.Admin.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductComment;

public class IndexModel : PageModel
{
    private readonly IProductCommentApplication _productCommentApplication;
    private readonly IAdminProductCommentQuery _adminProductCommentQuery;

    public List<AdminProductCommentQueryModel> ViewModels { get; set; }

    public IndexModel(IProductCommentApplication productCommentApplication,
        IAdminProductCommentQuery adminProductCommentQuery)
    {
        _productCommentApplication = productCommentApplication;
        _adminProductCommentQuery = adminProductCommentQuery;
    }

    public void OnGet()
    {
        ViewModels = _adminProductCommentQuery.GetViewModels();
    }

    public IActionResult OnGetConfirmComment(long id)
    {
        var statusCommand = new EditProductCommentStatusCommand()
        {
            AdminId = 0,
            CommentId = id
        };
        _productCommentApplication.Confirmed(statusCommand);
        return RedirectToPage("index");
    }

    public IActionResult OnGetDenyComment(long id)
    {
        var statusCommand = new EditProductCommentStatusCommand()
        {
            AdminId = 0,
            CommentId = id
        };
        _productCommentApplication.Deny(statusCommand);
        return RedirectToPage("index");
    }

}