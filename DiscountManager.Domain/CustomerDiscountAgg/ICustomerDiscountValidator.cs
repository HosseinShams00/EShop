namespace DiscountManager.Domain.CustomerDiscountAgg;

public interface ICustomerDiscountValidator
{
    void CheckTitleExist(string title);
    void CheckTitleExist(string title, long id);
    void CheckDiscountPercent(int discountPercent);
    void CheckDateTime(DateTime startDateTime, DateTime endDateTime);
}
