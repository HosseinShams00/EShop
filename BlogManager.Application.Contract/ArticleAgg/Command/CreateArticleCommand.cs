﻿namespace BlogManager.Application.Contract.ArticleAgg.Command;

public class CreateArticleCommand
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Slug { get; set; }
    public string Keywords { get; set; }
    public string MetaDescription { get; set; }
    public long CategoryId { get; set; }
}