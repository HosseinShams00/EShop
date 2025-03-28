﻿using BaseFramework.Domain.BaseDomainAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg;

public class Product : BaseDomain , IProduct
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ShortDescription { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }
    public long ProductCategoryId { get; private set; }
    public ProductCategory ProductCategory { get; private set; }
    public IReadOnlyCollection<ProductPicture> ProductPictures { get; private set; }

    protected Product()
    {
        ProductPictures = new List<ProductPicture>();
    }

    public Product(string name, string description,
        string shortDescription, string picture,
        string pictureAlt, string pictureTitle,
        string keywords, string metaDescription,
        string slug, long productCategoryId, IProductValidator validator)
    {
        validator.CheckNameExist(name);
        Name = name;
        Description = description;
        ShortDescription = shortDescription;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
        ProductCategoryId = productCategoryId;
    }

    public void Edit(string name, string description,
        string shortDescription, string picture,
        string pictureAlt, string pictureTitle,
        string keywords, string metaDescription,
        string slug, long productCategoryId, IProductValidator validator)
    {
        validator.CheckNameExistWithId(name, Id);
        Name = name;
        Description = description;
        ShortDescription = shortDescription;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
        validator.CheckCategoryIdExist(productCategoryId);
        ProductCategoryId = productCategoryId;

    }

}