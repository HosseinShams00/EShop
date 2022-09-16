namespace DiscountManager.Domain.CustomerDiscountAgg;

public interface ICustomerDiscountValidator
{
    void CheckTitleExist(string title);
    void CheckDiscountPercent(int discountPercent);
    void CheckDateTime(DateTime startDateTime, DateTime endDateTime);
}
