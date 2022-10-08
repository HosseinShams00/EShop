using BaseFramework.Repository;

namespace BlogManager.Domain.ArticleAgg;

public interface IArticleRepository : IBaseRepository<long, Article>
{
}