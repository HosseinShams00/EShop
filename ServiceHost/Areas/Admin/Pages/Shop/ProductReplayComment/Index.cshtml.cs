using CommentManager.Application.Contract.ProductReplayCommentAgg;
using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;
using EShopQuery.Contracts.Admin.ProductReplayComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductReplayComment;

public class IndexModel : PageModel
{
    private readonly IProductReplayCommentApplication _productReplayCommentApplication;
    private readonly IAdminProductReplayCommentQuery _adminProductReplayCommentQuery;

    public List<AdminProductReplayCommentQueryModel> ViewModels { get; set; }

    public IndexModel(IProductReplayCommentApplication productReplayCommentApplication,
        IAdminProductReplayCommentQuery adminProductReplayCommentQuery)
    {
        _productReplayCommentApplication = productReplayCommentApplication;
        _adminProductReplayCommentQuery = adminProductReplayCommentQuery;
    }

    public void OnGet()
    {
        ViewModels = _adminProductReplayCommentQuery.GetViewModels();
    }

    public IActionResult OnGetConfirmReplayComment(long id)
    {
        var statusCommand = new EditProductReplayCommentStatusCommand()
        {
            AdminId = 0,
            CommentId = id
        };
        _productReplayCommentApplication.Confirmed(statusCommand);
        return RedirectToPage("index");
    }

    public IActionResult OnGetDenyReplayComment(long id)
    {
        var statusCommand = new EditProductReplayCommentStatusCommand()
        {
            AdminId = 0,
            CommentId = id
        };
        _productReplayCommentApplication.Deny(statusCommand);
        return RedirectToPage("index");
    }

}