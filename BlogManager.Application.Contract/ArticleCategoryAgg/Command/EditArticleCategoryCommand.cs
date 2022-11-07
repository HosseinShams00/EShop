namespace BlogManager.Application.Contract.ArticleCategoryAgg.Command;

public class EditArticleCategoryCommand : CreateArticleCategoryCommand
{
    public long Id { get; set; }
}