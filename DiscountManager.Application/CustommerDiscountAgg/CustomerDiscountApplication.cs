using BaseFramework.Application.Exceptions;
using DiscountManager.Application.Contracts.CustommerDiscountAgg;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Command;
using DiscountManager.Application.Contracts.CustommerDiscountAgg.Exceptions;
using DiscountManager.Domain.CustomerDiscountAgg;

namespace DiscountManager.Application.CustommerDiscountAgg;

public class CustomerDiscountApplication : ICustomerDiscountApplication
{
    private readonly ICustomerDiscountRepository Repository;
    public ICustomerDiscountValidator Validator { get; }


    public CustomerDiscountApplication(ICustomerDiscountRepository repository, ICustomerDiscountValidator validator)
    {
        Repository = repository;
        Validator = validator;
    }

    public void Create(DefineCustomerDiscount customerDiscount)
    {
        try
        {
            Repository.Create(new CustomerDiscount(
                customerDiscount.Title, customerDiscount.Description,
                customerDiscount.StartDateTime, customerDiscount.EndDateTime,
                customerDiscount.DiscountPercent, Validator));
        }

        catch (Exception ex)
        {
            if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountPercentNotValidException)
                throw new DiscountPercentNotValidException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountTitletExistException)
                throw new DiscountTitletExistException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.EndDateTimeBiggerThanStartDateTimeException)
                throw new EndDateTimeBiggerThanStartDateTimeException();
        }

    }

    public void Delete(long id)
    {
        var entity = Repository.GetBy(id);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.DeActive();
        Repository.UpdateEntity(entity);
    }

    public void Restore(long id)
    {
        var entity = Repository.GetBy(id);

        if (entity == null)
            throw new EntityNotFoundException();

        entity.Active();
        Repository.UpdateEntity(entity);
    }

    public void Update(EditCustomerDiscount editProduct)
    {
        var customerDiscount = Repository.GetBy(editProduct.Id);

        if (customerDiscount == null)
            throw new EntityNotFoundException();

        try
        {
            customerDiscount.Edit(editProduct.Title, editProduct.Description,
                                  editProduct.StartDateTime, editProduct.EndDateTime,
                                  editProduct.DiscountPercent, Validator);

            Repository.UpdateEntity(customerDiscount);
        }
        catch (Exception ex)
        {
            if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountPercentNotValidException)
                throw new DiscountPercentNotValidException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.DiscountTitletExistException)
                throw new DiscountTitletExistException();
            else if (ex is Domain.CustomerDiscountAgg.Exceptions.EndDateTimeBiggerThanStartDateTimeException)
                throw new EndDateTimeBiggerThanStartDateTimeException();
        }
    }
}
