using CommentManager.Domain.ProductCommentAgg;
using CommentManager.Domain.ReplayCommentAgg;
using Microsoft.EntityFrameworkCore;

namespace CommentManager.Infrastructure.EfCore;

public class CommentManagerEFCoreDbContext : DbContext
{
    public CommentManagerEFCoreDbContext(DbContextOptions<CommentManagerEFCoreDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<ProductReplayComment> ProductReplayComments { get; set; } 
    
}