using ShopManagement.Domain.ProductAgg.Exceptions;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg;

public class ProductValidator : IProductValidator
{
    private readonly IProductRepository productRepository;
    private readonly IProductCategoryRepository productCategoryRepositroy;

    public ProductValidator(IProductRepository productRepository, IProductCategoryRepository productCategoryRepositroy)
    {
        this.productRepository = productRepository;
        this.productCategoryRepositroy = productCategoryRepositroy;
    }

    public void CheckCategoryIdExist(long id)
    {
        if (productCategoryRepositroy.Exist(x => x.Id == id) == false)
            throw new CategoryIdNotExistException();
    }

    public void CheckNameExist(string name)
    {
        if (productRepository.Exist(x => x.Name == name))
            throw new DuplicateProductNameException();
    }

    public void CheckNameExistWithId(string name, long id)
    {
        if (productRepository.Exist(x => x.Name == name && x.Id != id))
            throw new DuplicateProductNameException();
    }
}