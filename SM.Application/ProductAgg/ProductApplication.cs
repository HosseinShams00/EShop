using BaseFramework.Application.Exceptions;
using ShopManagement.Application.Contract.ProductAgg.Exceptions;
using ShopManagement.Domain.ProductAgg;
using BaseFramework.Application;
using InventoryManager.Applicaton.Contract.InventoryAgg.Command;
using SecondaryDB.Domain;
using ShopManagement.Application.Contract.ProductAgg.Command;
using ShopManagement.Application.Contract.ProductAgg;
using InventoryManager.Applicaton.Contract.InventoryAgg;

namespace ShopManagement.Application.ProductAgg;

public class ProductApplication : IProductApplication
{
    private readonly IProductValidator _validator;

    private readonly IProductRepository _productRepository;
    private readonly IInventoryApplication _inventoryApplication;
    private readonly IProductQueryRepository _productQueryRepository;

    public ProductApplication(IProductRepository productRepository,
        IProductValidator validator,
        IInventoryApplication inventoryApplication,
        IProductQueryRepository productQueryRepository)
    {
        _productRepository = productRepository;
        _validator = validator;
        _inventoryApplication = inventoryApplication;
        _productQueryRepository = productQueryRepository;
    }

    public void Create(CreateProduct createProduct)
    {
        if (_productRepository.Exist(x => x.Name == createProduct.Name))
            throw new DuplicatedEntityNameException();

        try
        {
            var entity = new Product(createProduct.Name, createProduct.Description,
                createProduct.ShortDecription, createProduct.Picture,
                createProduct.PictureAlt, createProduct.PictureTitle,
                createProduct.Keywords, createProduct.MetaDescription,
                createProduct.Slug.ModifySlug(), createProduct.ProductCategoryId, _validator);

            _productRepository.Create(entity);

            var productQuery = Convertor.Convert<ProductQuery>(entity);
            _productQueryRepository.Create(productQuery);

            _inventoryApplication.Create(new CreateInventoryCommand()
            {
                ProductId = entity.Id,
                UnitPrice = createProduct.UnitPrice
            });
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductAgg.Exceptions.DuplicateProductNameException)
                throw new DuplicateProductNameException();
        }
    }

    public void Update(EditProduct editProduct)
    {
        var entity = _productRepository.GetBy(editProduct.Id);

        if (entity is null)
            throw new EntityNotFoundException();

        if (_productRepository.Exist(x => x.Name == editProduct.Name && x.Id != editProduct.Id))
            throw new DuplicatedEntityNameException();

        try
        {
            entity.Edit(editProduct.Name, editProduct.Description,
            editProduct.ShortDecription, editProduct.Picture,
            editProduct.PictureAlt, editProduct.PictureTitle,
            editProduct.Keywords, editProduct.MetaDescription,
            editProduct.Slug.ModifySlug(), editProduct.ProductCategoryId, _validator);

            _productRepository.UpdateEntity(entity);

            var productQuery = _productQueryRepository.Get(x => x.Id == entity.Id);
            Convertor.Copy(entity, productQuery);
            _productQueryRepository.UpdateEntity(productQuery);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductAgg.Exceptions.DuplicateProductNameException)
                throw new DuplicateProductNameException();

            else if (ex is Domain.ProductAgg.Exceptions.CategoryIdNotExistException)
                throw new CategoryIdNotExistException();
        }
    }

    public void Delete(long id)
    {
        var entity = _productRepository.GetBy(id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.DeActive();
        _productRepository.UpdateEntity(entity);

        var productQuery = _productQueryRepository.Get(x => x.Id == entity.Id);
        productQuery.IsRemoved = entity.IsRemoved;
        _productQueryRepository.UpdateEntity(productQuery);
    }

    public void Restore(long id)
    {
        var entity = _productRepository.GetBy(id);
        if (entity is null)
            throw new EntityNotFoundException();

        entity.Active();
        _productRepository.UpdateEntity(entity);

        var productQuery = _productQueryRepository.Get(x => x.Id == entity.Id);
        productQuery.IsRemoved = entity.IsRemoved;
        _productQueryRepository.UpdateEntity(productQuery);
    }
}
