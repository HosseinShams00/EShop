using _0_Framework.Application;
using BaseFramwork.Application.Exceptions;
using ShopManagement.Application.Constracts.ProductAgg;
using ShopManagement.Application.Constracts.ProductAgg.Exceptions;
using ShopManagement.Application.Constracts.ProductAgg.Command;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application.ProductAgg;

public class ProductApplication : IProductApplication
{
    private readonly IProductValidator validator;

    private readonly IProductRepository ProductRepository;

    public ProductApplication(IProductRepository productRepository, IProductValidator validator)
    {
        ProductRepository = productRepository;
        this.validator = validator;
    }

    public void Create(CreateProduct createProduct)
    {
        if (ProductRepository.Exist(x => x.Name == createProduct.Name))
            throw new DuplicatedEntityException();

        try
        {
            var product = new Product(createProduct.Name, createProduct.Description,
                createProduct.ShortDecription, createProduct.Picture,
                createProduct.PictureAlt, createProduct.PictureTitle,
                createProduct.Keywords, createProduct.MetaDescription,
                createProduct.Slug.ModifySlug(), createProduct.ProductCategoryId, validator);

            ProductRepository.Create(product);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductAgg.Exceptions.DuplicateProductNameException)
                throw new DuplicateProductNameException();
        }
    }

    public void Update(EditProduct editProduct)
    {
        var productCategory = ProductRepository.GetBy(editProduct.Id);

        if (productCategory is null)
            throw new EntityNotFoundException();

        if (ProductRepository.Exist(x => x.Name == editProduct.Name && x.Id != editProduct.Id))
            throw new DuplicatedEntityException();

        try
        {
            productCategory.Edit(editProduct.Name, editProduct.Description,
            editProduct.ShortDecription, editProduct.Picture,
            editProduct.PictureAlt, editProduct.PictureTitle,
            editProduct.Keywords, editProduct.MetaDescription,
            editProduct.Slug.ModifySlug(), editProduct.ProductCategoryId, validator);

            ProductRepository.SaveChanges(productCategory);
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
        var product = ProductRepository.GetBy(id);
        if (product == null)
            throw new EntityNotFoundException();

        product.DeActive();
        ProductRepository.SaveChanges(product);
    }

    public EditProduct GetDetail(long id)
    {
        var product = ProductRepository.GetDetail(id);
        if (product is null)
            throw new EntityNotFoundException();

        return product;
    }

    public void Restore(long id)
    {
        var product = ProductRepository.GetBy(id);
        if (product is null)
            throw new EntityNotFoundException();

        product.Active();
        ProductRepository.SaveChanges(product);
    }

    public List<ProductViewModel> Search(ProductSearchModel productSearchModel)
    {
        return ProductRepository.Search(productSearchModel);
    }

}
