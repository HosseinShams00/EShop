using BaseFramework.Application.Exceptions;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using DiscountManager.Domain.ProductCustomerDiscountAgg;

namespace DiscountManager.Application.ProductCustomerDiscountAgg;

public class ProductCustomerDiscountApplication : IProductCustomerDiscountApplication
{
    private readonly IProductCustomerDiscountRepository Repository;
    private readonly IProductCustomerDiscountValidator Validator;

    public ProductCustomerDiscountApplication(IProductCustomerDiscountRepository repository, IProductCustomerDiscountValidator validator)
    {
        Repository = repository;
        Validator = validator;
    }

    public void Create(ProdcutCustomerCommand customerDiscount)
    {
        Repository.Create(new ProductCustomerDiscount(customerDiscount.ProductId, customerDiscount.CustomerDiscountId, Validator));
    }

    public void DeleteBy(long productId)
    {
        Repository.RemoveBy(productId);
    }

    public long GetCustomerDiscountId(long productId)
    {
        return Repository.GetCustomerDiscountId(productId);
    }

    public void Update(EditProdcutCustomerCommand editCustomerDiscount)
    {
        var editCommand = Repository.GetBy(editCustomerDiscount.Id);

        if (editCommand == null)
            throw new EntityNotFoundException();

        editCommand.EditCustomerDiscountId(editCustomerDiscount.CustomerDiscountId, Validator);
        Repository.UpdateEntity(editCommand);
    }

}
