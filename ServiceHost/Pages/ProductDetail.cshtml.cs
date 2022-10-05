using CommentManager.Application.Contract.ProductCommentAgg;
using CommentManager.Application.Contract.ProductCommentAgg.Command;
using CommentManager.Application.Contract.ProductReplayCommentAgg;
using CommentManager.Application.Contract.ProductReplayCommentAgg.Command;
using EShopQuery.Contracts.User.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class ProductDetailModel : PageModel
{
    private readonly IUserProductQuery _productQuery;
    private readonly IProductCommentApplication _productCommentApplication;
    //private readonly IProductReplayCommentApplication _productReplayCommentApplication;
    public UserProductQueryModel ViewModel { get; private set; }
    [BindProperty] public CreateProductCommentCommand? CreateProductCommentCommand { get; set; }
    //[BindProperty] public CreateProductReplayCommentCommand? CreateProductReplayCommentCommand { get; set; }

    public ProductDetailModel(IUserProductQuery productQuery,
        IProductCommentApplication productCommentApplication)
    {
        _productQuery = productQuery;
        _productCommentApplication = productCommentApplication;
        //_productReplayCommentApplication = productReplayCommentApplication;
    }

    public IActionResult OnGet(long id, string? slug)
    {
        var productQueryModelFull = _productQuery.GetProductQueryModelFull(id);
        if (productQueryModelFull == null)
        {
            return NotFound();
        }

        ViewModel = productQueryModelFull;
        return Page();
    }

    public IActionResult OnPostComment()
    {
        if (CreateProductCommentCommand != null)
            _productCommentApplication.Create(CreateProductCommentCommand);

        return RedirectToPage("ProductDetail", new { id = CreateProductCommentCommand?.ProductId });
    }

    //public void OnPostReplayComment()
    //{
    //    if (CreateProductReplayCommentCommand == null)
    //        return;

    //    _productReplayCommentApplication.Create(CreateProductReplayCommentCommand);
    //}
}