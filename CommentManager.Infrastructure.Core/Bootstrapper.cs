using CommentManager.Application;
using CommentManager.Application.Contract.ProductCommentAgg;
using CommentManager.Application.Contract.ProductReplayCommentAgg;
using CommentManager.Domain.ProductCommentAgg;
using CommentManager.Domain.ReplayCommentAgg;
using CommentManager.Infrastructure.EfCore;
using CommentManager.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManager.Infrastructure.Core;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<CommentManagerEFCoreDbContext>(x => x.UseSqlServer(stringConnection));
        services.AddTransient<IProductCommentApplication, ProductCommentApplication>();
        services.AddTransient<IProductCommentRepository, ProductCommentRepository>();
        services.AddTransient<IProductReplayCommentApplication, ProductReplayCommentApplication>();
        services.AddTransient<IProductReplayCommentRepository, ProductReplayCommentRepository>();
    }
}