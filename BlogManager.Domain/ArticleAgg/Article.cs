﻿using BaseFramework.Domain.BaseDomainAgg;
using BlogManager.Domain.ArticleCategoryAgg;

namespace BlogManager.Domain.ArticleAgg;

public class Article : BaseDomain, IArticle
{
    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Slug { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public long CategoryId { get; private set; }
    public ArticleCategory? Category { get; private set; }

    protected Article()
    {
        
    }

    public Article(string title, string shortDescription,
        string description, string picture,
        string pictureAlt, string pictureTitle,
        string slug, string keywords,
        string metaDescription, long categoryId)
    {
        Title = title;
        ShortDescription = shortDescription;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Slug = slug;
        Keywords = keywords;
        MetaDescription = metaDescription;
        CategoryId = categoryId;
    }

    public void Edit(string title, string shortDescription,
        string description, string picture,
        string pictureAlt, string pictureTitle,
        string slug, string keywords,
        string metaDescription, long categoryId)
    {
        Title = title;
        ShortDescription = shortDescription;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Slug = slug;
        Keywords = keywords;
        MetaDescription = metaDescription;
        CategoryId = categoryId;
    }
}