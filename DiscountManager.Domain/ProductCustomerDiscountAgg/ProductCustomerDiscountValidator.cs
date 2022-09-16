using DiscountManager.Domain.CustomerDiscountAgg;
using DiscountManager.Domain.ProductCustomerDiscountAgg.Exceptions;

namespace DiscountManager.Domain.ProductCustomerDiscountAgg;

public class ProductCustomerDiscountValidator : IProductCustomerDiscountValidator
{
    private readonly IProductCustomerDiscountRepository ProductDiscountRepository;
    private readonly ICustomerDiscountRepository Repository;

    public ProductCustomerDiscountValidator(ICustomerDiscountRepository repository, IProductCustomerDiscountRepository productDiscountRepository)
    {
        Repository = repository;
        ProductDiscountRepository = productDiscountRepository;
    }


    public void CheckCustomerDiscountId(long id)
    {
        if (Repository.Exist(x => x.Id == id) == false)
            throw new CustomerDiscountIdNotExistEception();
    }

    public void CheckProductId(long id)
    {
        if (ProductDiscountRepository.Exist(x => x.ProductId == id))
            throw new DulicatedProductIdExistException();
    }
}