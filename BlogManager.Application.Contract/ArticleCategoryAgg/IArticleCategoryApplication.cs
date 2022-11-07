using BlogManager.Application.Contract.ArticleCategoryAgg.Command;

namespace BlogManager.Application.Contract.ArticleCategoryAgg;

public interface IArticleCategoryApplication
{
    void Create(CreateArticleCategoryCommand command);
    void Update(EditArticleCategoryCommand command);
}