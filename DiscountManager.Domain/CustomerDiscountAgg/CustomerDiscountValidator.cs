using DiscountManager.Domain.CustomerDiscountAgg.Exceptions;

namespace DiscountManager.Domain.CustomerDiscountAgg;

public class CustomerDiscountValidator : ICustomerDiscountValidator
{
    private readonly ICustomerDiscountRepository Repository;

    public CustomerDiscountValidator(ICustomerDiscountRepository repository)
    {
        this.Repository = repository;
    }

    public void CheckDiscountPercent(int discountPercent)
    {
        if (discountPercent < 1 && discountPercent > 99)
            throw new DiscountPercentNotValidException();
    }

    public void CheckDateTime(DateTime startDateTime, DateTime endDateTime)
    {
        if (endDateTime <= startDateTime)
            throw new EndDateTimeBiggerThanStartDateTimeException();
    }

    public void CheckTitleExist(string title)
    {
        if (Repository.Exist(x => x.Title == title))
            throw new DiscountTitletExistException();
    }

}