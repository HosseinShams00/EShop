using BaseFramework.Application.Exceptions;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg;
using DiscountManager.Application.Contracts.ProductCustomerDiscountAgg.Command;
using DiscountManager.Domain.CustomerDiscountAgg;
using DiscountManager.Domain.ProductCustomerDiscountAgg;
using SecondaryDB.Domain.ProductQueryAgg;

namespace DiscountManager.Application.ProductCustomerDiscountAgg;

public class ProductCustomerDiscountApplication : IProductCustomerDiscountApplication
{
    private readonly IProductCustomerDiscountRepository _repository;
    private readonly IProductCustomerDiscountValidator _validator;
    private readonly IProductQueryRepository _productQueryRepository;

    public ProductCustomerDiscountApplication(IProductCustomerDiscountRepository repository,
        IProductCustomerDiscountValidator validator,
        IProductQueryRepository productQueryRepository)
    {
        _repository = repository;
        _validator = validator;
        _productQueryRepository = productQueryRepository;
    }

    public void Create(ProdcutCustomerCommand customerDiscount)
    {
        var entity = new ProductCustomerDiscount(customerDiscount.ProductId, customerDiscount.CustomerDiscountId, _validator);
        _repository.Create(entity);

        _productQueryRepository.AddDiscount(entity.ProductId, entity.CustomerDiscountId);
    }

    public void DeleteBy(long productId)
    {
        _repository.RemoveBy(productId);
        _productQueryRepository.RemoveDiscount(productId);
    }

    public long GetCustomerDiscountId(long productId)
    {
        return _repository.GetCustomerDiscountId(productId);
    }

    public void Update(EditProdcutCustomerCommand editCustomerDiscount)
    {
        var entity = _repository.GetBy(editCustomerDiscount.Id);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.EditCustomerDiscountId(editCustomerDiscount.CustomerDiscountId, _validator);
        _repository.UpdateEntity(entity);

        _productQueryRepository.EditDiscount(entity.ProductId, entity.CustomerDiscountId);
    }

}
