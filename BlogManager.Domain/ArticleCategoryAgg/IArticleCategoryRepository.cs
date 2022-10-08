using BaseFramework.Repository;

namespace BlogManager.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository : IBaseRepository<long, ArticleCategory>
{
}