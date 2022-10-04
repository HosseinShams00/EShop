using BaseFramework.Application;
using BaseFramework.Application.Exceptions;
using ShopManagement.Application.Contract.ProductCategroyAgg.Exceptions;
using ShopManagement.Application.Contract.ProductCategroyAgg;
using ShopManagement.Application.Contract.ProductCategroyAgg.Command;
using ShopManagement.Domain.ProductCategoryAgg;
using SecondaryDB.Domain.ProductCategoryQueryAgg;

namespace ShopManagement.Application.ProductCategoryAgg;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductCategoryValidator _validator;
    private readonly IProductCategoryQueryRepository _productCategoryQueryRepository;

    public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository,
        IProductCategoryValidator validator,
        IProductCategoryQueryRepository productCategoryQueryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
        _validator = validator;
        _productCategoryQueryRepository = productCategoryQueryRepository;
    }

    public void Create(CreateProductCategory createProductCategory)
    {
        if (_productCategoryRepository.Exist(x => x.Name == createProductCategory.Name))
            throw new DuplicatedProductCategoryNameException();

        try
        {
            var entity = new ProductCategory(createProductCategory.Name, createProductCategory.Description,
            createProductCategory.Picture, createProductCategory.PictureAlt,
            createProductCategory.PictureTitle, createProductCategory.Keywords,
            createProductCategory.MetaDescription, createProductCategory.Slug.ModifySlug(), _validator);

            _productCategoryRepository.Create(entity);
            var categoryQuery = Convertor.Convert<ProductCategoryQuery>(entity);
            _productCategoryQueryRepository.Create(categoryQuery);

        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductCategoryAgg.Exceptions.DuplicatedProductCategoryNameException)
                throw new DuplicatedProductCategoryNameException();

            throw;
        }
    }

    public void Update(EditProductCategory editProductCategory)
    {
        var entity = _productCategoryRepository.GetBy(editProductCategory.Id);

        if (entity is null)
            throw new EntityNotFoundException();

        if (_productCategoryRepository.Exist(x => x.Name == editProductCategory.Name && x.Id != editProductCategory.Id))
            throw new DuplicatedEntityNameException();

        try
        {
            entity.Edit(editProductCategory.Name, editProductCategory.Description,
            editProductCategory.Picture, editProductCategory.PictureAlt,
            editProductCategory.PictureTitle, editProductCategory.Keywords,
            editProductCategory.MetaDescription, editProductCategory.Slug.ModifySlug(), _validator);

            _productCategoryRepository.UpdateEntity(entity);

            var productCategoryQuery = _productCategoryQueryRepository.Get(x => x.Id == entity.Id);
            Convertor.Copy(entity, productCategoryQuery);
            _productCategoryQueryRepository.UpdateEntity(productCategoryQuery);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductCategoryAgg.Exceptions.DuplicatedProductCategoryNameException)
                throw new DuplicatedProductCategoryNameException();

            throw;
        }
    }

    public void Delete(long id)
    {
        var entity = _productCategoryRepository.GetBy(id);
        if (entity is null)
            throw new EntityNotFoundException();

        entity.DeActive();
        _productCategoryRepository.UpdateEntity(entity);

        var productCategoryQuery = _productCategoryQueryRepository.Get(x => x.Id == entity.Id);
        productCategoryQuery.IsRemoved = entity.IsRemoved;
        _productCategoryQueryRepository.UpdateEntity(productCategoryQuery);
    }

    public void Restore(long id)
    {
        var entity = _productCategoryRepository.GetBy(id);
        if (entity is null)
            throw new EntityNotFoundException();

        entity.Active();
        _productCategoryRepository.UpdateEntity(entity);

        var productCategoryQuery = _productCategoryQueryRepository.Get(x => x.Id == entity.Id);
        productCategoryQuery.IsRemoved = entity.IsRemoved;
        _productCategoryQueryRepository.UpdateEntity(productCategoryQuery);
    }
}