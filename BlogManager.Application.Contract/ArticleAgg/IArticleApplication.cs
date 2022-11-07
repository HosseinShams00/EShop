using BlogManager.Application.Contract.ArticleCategoryAgg.Command;

namespace BlogManager.Application.Contract.ArticleAgg;

public interface IArticleApplication
{
    void Create(CreateArticleCategoryCommand command);
    void Update(EditArticleCategoryCommand command);
}