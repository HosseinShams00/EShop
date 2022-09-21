using BaseFramwork.Application.Exceptions;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Exceptions;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Domain.ProductAgg;
using BaseFramwork.Application;
using InventoryManager.Applicaton.Contracts.InventoryAgg;
using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;

namespace ShopManagement.Application.ProductAgg;

public class ProductApplication : IProductApplication
{
    private readonly IProductValidator _Validator;

    private readonly IProductRepository _ProductRepository;
    private readonly IInventoryApplication _InventoryApplication;

    public ProductApplication(IProductRepository productRepository,
        IProductValidator validator,
        IInventoryApplication inventoryApplication)
    {
        _ProductRepository = productRepository;
        _Validator = validator;
        _InventoryApplication = inventoryApplication;
    }

    public void Create(CreateProduct createProduct)
    {
        if (_ProductRepository.Exist(x => x.Name == createProduct.Name))
            throw new DuplicatedEntityNameException();

        try
        {
            var product = new Product(createProduct.Name, createProduct.Description,
                createProduct.ShortDecription, createProduct.Picture,
                createProduct.PictureAlt, createProduct.PictureTitle,
                createProduct.Keywords, createProduct.MetaDescription,
                createProduct.Slug.ModifySlug(), createProduct.ProductCategoryId, _Validator);

            _ProductRepository.Create(product);
            _InventoryApplication.Create(new CreateInventoryCommand()
            {
                ProductId = product.Id,
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
        var productCategory = _ProductRepository.GetBy(editProduct.Id);

        if (productCategory is null)
            throw new EntityNotFoundException();

        if (_ProductRepository.Exist(x => x.Name == editProduct.Name && x.Id != editProduct.Id))
            throw new DuplicatedEntityNameException();

        try
        {
            productCategory.Edit(editProduct.Name, editProduct.Description,
            editProduct.ShortDecription, editProduct.Picture,
            editProduct.PictureAlt, editProduct.PictureTitle,
            editProduct.Keywords, editProduct.MetaDescription,
            editProduct.Slug.ModifySlug(), editProduct.ProductCategoryId, _Validator);

            _ProductRepository.UpdateEntity(productCategory);
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
        var product = _ProductRepository.GetBy(id);
        if (product == null)
            throw new EntityNotFoundException();

        product.DeActive();
        _ProductRepository.UpdateEntity(product);
    }

    public void Restore(long id)
    {
        var product = _ProductRepository.GetBy(id);
        if (product is null)
            throw new EntityNotFoundException();

        product.Active();
        _ProductRepository.UpdateEntity(product);
    }
}
