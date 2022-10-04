using BaseFramework.Application;
using BaseFramework.Application.Exceptions;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Exceptions;
using DiscountManager.Domain.CustomerDiscountAgg;
using SecondaryDB.Domain.CustomerDiscountQueryAgg;
using ShopManagement.Domain.ProductAgg;

namespace DiscountManager.Application.CustomerDiscountAgg;

public class CustomerDiscountApplication : ICustomerDiscountApplication
{
    private readonly ICustomerDiscountRepository _repository;
    private readonly ICustomerDiscountValidator _validator;
    private readonly ICustomerDiscountQueryRepository _customerDiscountQueryRepository;


    public CustomerDiscountApplication(ICustomerDiscountRepository repository,
        ICustomerDiscountValidator validator,
        ICustomerDiscountQueryRepository customerDiscountQueryRepository)
    {
        _repository = repository;
        _validator = validator;
        _customerDiscountQueryRepository = customerDiscountQueryRepository;
    }

    public void Create(DefineCustomerDiscount customerDiscount)
    {
        try
        {
            var entity = new CustomerDiscount(
                customerDiscount.Title, customerDiscount.Description,
                customerDiscount.StartDateTime, customerDiscount.EndDateTime,
                customerDiscount.DiscountPercent, _validator);

            _repository.Create(entity);

            var discountQuery = Convertor.Convert<CustomerDiscountQuery>(entity);
            _customerDiscountQueryRepository.Create(discountQuery);
        }

        catch (Exception ex)
        {
            if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountPercentNotValidException)
                throw new DiscountPercentNotValidException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountTitletExistException)
                throw new DiscountTitletExistException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.EndDateTimeBiggerThanStartDateTimeException)
                throw new EndDateTimeBiggerThanStartDateTimeException();

            throw;
        }

    }

    public void Delete(long id)
    {
        var entity = _repository.GetBy(id);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.DeActive();
        _repository.UpdateEntity(entity);

        var discountQuery = _customerDiscountQueryRepository.Get(x => x.Id == entity.Id);
        discountQuery.IsRemoved = entity.IsRemoved;
        _customerDiscountQueryRepository.UpdateEntity(discountQuery);
    }

    public void Restore(long id)
    {
        var entity = _repository.GetBy(id);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Active();
        _repository.UpdateEntity(entity);

        var discountQuery = _customerDiscountQueryRepository.Get(x => x.Id == entity.Id);
        discountQuery.IsRemoved = entity.IsRemoved;
        _customerDiscountQueryRepository.UpdateEntity(discountQuery);
    }

    public void Update(EditCustomerDiscount editProduct)
    {
        var entity = _repository.GetBy(editProduct.Id);

        if (entity == null)
            throw new EntityNotFoundException();

        try
        {
            entity.Edit(editProduct.Title, editProduct.Description,
                                  editProduct.StartDateTime, editProduct.EndDateTime,
                                  editProduct.DiscountPercent, _validator);

            _repository.UpdateEntity(entity);

            var discountQuery = _customerDiscountQueryRepository.Get(x => x.Id == entity.Id);
            Convertor.Copy(entity, discountQuery);
            _customerDiscountQueryRepository.UpdateEntity(discountQuery);
        }
        catch (Exception ex)
        {
            if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountPercentNotValidException)
                throw new DiscountPercentNotValidException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountTitletExistException)
                throw new DiscountTitletExistException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.EndDateTimeBiggerThanStartDateTimeException)
                throw new EndDateTimeBiggerThanStartDateTimeException();

            throw;
        }
    }
}
