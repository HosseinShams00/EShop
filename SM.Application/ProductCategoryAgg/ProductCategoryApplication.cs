using _0_Framework.Application;
using BaseFramwork.Application.Exceptions;
using ShopManagement.Application.Constracts.ProductCategroyAgg;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Command;
using ShopManagement.Application.Constracts.ProductCategroyAgg.Exceptions;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application.ProductCategoryAgg;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository ProductCategoryRepository;
    private readonly IProductCategoryValidator validator;

    public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IProductCategoryValidator validator)
    {
        ProductCategoryRepository = productCategoryRepository;
        this.validator = validator;
    }

    public void Create(CreateProductCategory createProductCategory)
    {
        if (ProductCategoryRepository.Exist(x => x.Name == createProductCategory.Name))
            throw new DuplicatedProductCategoryNameException();

        try
        {
            var productCategory = new ProductCategory(createProductCategory.Name, createProductCategory.Description,
            createProductCategory.Picture, createProductCategory.PictureAlt,
            createProductCategory.PictureTitle, createProductCategory.Keywords,
            createProductCategory.MetaDescription, createProductCategory.Slug.ModifySlug(), validator);

            ProductCategoryRepository.Create(productCategory);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductCategoryAgg.Exceptions.DuplicatedProductCategoryNameException)
                throw new DuplicatedProductCategoryNameException();
        }
    }

    public void Update(EditProductCategory editProductCategory)
    {
        var productCategory = ProductCategoryRepository.GetBy(editProductCategory.Id);

        if (productCategory is null)
            throw new EntityNotFoundException();

        if (ProductCategoryRepository.Exist(x => x.Name == editProductCategory.Name && x.Id != editProductCategory.Id))
            throw new DuplicatedEntityNameException();

        try
        {
            productCategory.Edit(editProductCategory.Name, editProductCategory.Description,
            editProductCategory.Picture, editProductCategory.PictureAlt,
            editProductCategory.PictureTitle, editProductCategory.Keywords,
            editProductCategory.MetaDescription, editProductCategory.Slug.ModifySlug(), validator);

            ProductCategoryRepository.SaveChanges(productCategory);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductCategoryAgg.Exceptions.DuplicatedProductCategoryNameException)
                throw new DuplicatedProductCategoryNameException();
        }
    }

    public EditProductCategory GetDetail(long id)
    {
        var detail = ProductCategoryRepository.GetDetail(id);
        if (detail == null)
            throw new EntityNotFoundException();

        return detail;
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel)
    {
        return ProductCategoryRepository.Search(productCategorySearchModel);
    }

    public void Delete(long id)
    {
        var category = ProductCategoryRepository.GetBy(id);
        if (category is null)
            throw new EntityNotFoundException();

        category.DeActive();
        ProductCategoryRepository.SaveChanges(category);
    }

    public void Restore(long id)
    {
        var category = ProductCategoryRepository.GetBy(id);
        if (category is null)
            throw new EntityNotFoundException();

        category.Active();
        ProductCategoryRepository.SaveChanges(category);
    }

    public List<ProductCategoryViewModel> GetAll()
    {
        return ProductCategoryRepository.GetViewModels();
    }
}