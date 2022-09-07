namespace ShopManagement.Domain.ProductCategoryAgg;

public interface IProductCategoryValidator
{
    void CheckCategoryNameExist(string name);
    void CheckCategoryNameExistWithId(string name, long id);
}
