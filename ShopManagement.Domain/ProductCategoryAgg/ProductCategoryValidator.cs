using ShopManagement.Domain.ProductCategoryAgg.Exceptions;

namespace ShopManagement.Domain.ProductCategoryAgg;

public class ProductCategoryValidator : IProductCategoryValidator
{
    private readonly IProductCategoryRepository productCategoryRepository;

    public ProductCategoryValidator(IProductCategoryRepository productCategoryRepository)
    {
        this.productCategoryRepository = productCategoryRepository;
    }

    public void CheckCategoryNameExist(string name)
    {
        if (productCategoryRepository.Exist(x => x.Name == name))
            throw new DuplicatedProductCategoryNameException();
    }

    public void CheckCategoryNameExistWithId(string name, long id)
    {
        if (productCategoryRepository.Exist(x => x.Name == name && x.Id != id))
            throw new DuplicatedProductCategoryNameException();
    }
}