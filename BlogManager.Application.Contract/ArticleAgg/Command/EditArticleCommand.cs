namespace BlogManager.Application.Contract.ArticleAgg.Command;

public class EditArticleCommand : CreateArticleCommand
{
    public long Id { get; set; }
}